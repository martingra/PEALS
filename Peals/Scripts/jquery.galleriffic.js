; (function ($) {
    // Se hace uso de un identificador Hash para cada recurso.
    var allResources = {};
    var resourceCounter = 0;

    var supportFormats = 
    { 
        "Image": { "id": 1, "formats": ".jpg" || ".png" || ".gif" }, 
        "Audio": { "id": 2, "formats": ".mp3" || ".ogg" || ".wav" }, 
        "Video": { "id": 3, "formats": ".mp4" || ".ogg" || ".webm"} 
    };

    // Galleriffic static class
    $.galleriffic = {
        version: '2.0.1',

        // Quita cualquier caracter especial
        normalizeHash: function (hash) {
            return hash.replace(/^.*#/, '').replace(/\?.*$/, '');
        },

        getResource: function (hash) {
            if (!hash)
                return undefined;

            hash = $.galleriffic.normalizeHash(hash);
            return allResources[hash];
        },

        // Función global que busca una resourcen en la tabla Hash y la muestra.
        // Returns false si no se encuentra el recurso
        // @param {String} hash - Valor hash asignado a una resourcen
        gotoResource: function (hash) {
            var resourceData = $.galleriffic.getResource(hash);
            if (!resourceData)
                return false;

            var gallery = resourceData.gallery;
            gallery.gotoResource(resourceData);

            return true;
        },

        // Elimina un recurso de la galeria identicandola por su código hash.
        // Returns false si no se encuentra el recurso
        // @param {String} hash Código hash que identifica a la resourcen.
        // @param {Object} ownerGallery (Opcional) Es la ubicación de la galeria.
        removeResourceByHash: function (hash, ownerGallery) {
            var resourceData = $.galleriffic.getResource(hash);
            if (!resourceData)
                return false;

            var gallery = resourceData.gallery;
            if (ownerGallery && ownerGallery != gallery)
                return false;

            return gallery.removeResourceByIndex(resourceData.index);
        }
    };

    var defaults = {
        delay:                     3000,
        numThumbs:                 20,
        preloadAhead:              40, // Setiar como -1 para precargar todos los recursos.
        enableTopPager:            false,
        enableBottomPager:         true,
        maxPagesToShow:            7,
        resourceContainerSel:      '',
        captionContainerSel:       '',
        controlsContainerSel:      '',
        loadingContainerSel:       '',
        renderNavControls:         true,
        prevLinkText:              '&lsaquo; Anterior',
        nextLinkText:              'Siguiente &rsaquo;',
        nextPageLinkText:          'Siguiente &rsaquo;',
        prevPageLinkText:          '&lsaquo; Anterior',
        enableHistory:             false,
        enableKeyboardNavigation:  true,
        autoStart:                 false,
        syncTransitions:           false,
        defaultTransitionDuration: 1000,
        onSlideChange:             undefined, // function(prevIndex, nextIndex) { ... }
        onTransitionOut:           undefined, // function(slide, caption, isSync, callback) { ... }
        onTransitionIn:            undefined, // function(slide, caption, isSync) { ... }
        onPageTransitionOut:       undefined, // function(callback) { ... }
        onPageTransitionIn:        undefined, // function() { ... }
        onResourceAdded:           undefined, // function(resourceData, $li) { ... }
        onResourceRemoved:         undefined, // function(resourceData, $li) { ... }
        onPressEnter:              undefined, // function() { ... }
        onDoubleClick:             undefined  // function(id, source, title) { ... }
    };

    // Inicia la galería
    $.fn.galleriffic = function (settings) {
        //  Extend Gallery Object
        $.extend(this, {
            // Versión del script
            version: $.galleriffic.version,

            // Estado actual del slideshow
            isSlideshowRunning: false,
            slideshowTimeout: undefined,

            // Evento click generado por un hiperlink dentro del recurso.
            clickHandler: function (e, link) {
                if (!this.enableHistory) {
                    // The href attribute holds the unique hash for an resource
                    var hash = $.galleriffic.normalizeHash($(link).attr('href'));
                    $.galleriffic.gotoResource(hash);
                    e.preventDefault();
                }
            },

            // Agrega un listado de recursos
            // @param listItem - Lista de recursos que van a ser agregados. Puede ser un jQuery object o un string of html.
            appendResource: function (listItem) {
                this.addResource(listItem, false, false);
                return this;
            },

            // Agrega un recurso o varios a los ya existentes.
            // @param listItem - Lista de recursos que van a ser agregados. Puede ser un jQuery object o un string of html.
            // @param {Integer} position - Posición donde se agregará.
            insertResource: function (listItem, position) {
                this.addResource(listItem, false, true, position);
                return this;
            },

            // Especifica el tipo de recurso que se va a agregar y crea el objeto html correspondiente.
            // @param id - ID del recurso
            // @param url - URL del recurso
            // @param title - Valor string que será utilizado como en el valor title del objecto.
            setType: function (id, url, title){
                var size = url.length;
                var format = url.substr(size - 6, size - 1).toLowerCase();

                if (format.search(supportFormats.Video.formats) != -1){
                    var tag = "<video id='" + id + "' src='" + url + "' title='" + title + "' controls='controls'></video>"
                    return { 'id': supportFormats.Video.id, 'formats': supportFormats.Video.formats, 'tag': tag };
                }
                else if (format.search(supportFormats.Audio.formats) != -1){                    
                    var tag = 
                        "<div class='audio-content'>" +
                        "   <img src='../Content/Resources/General/Audio.png' /> " +
                        "   <p>" + title + "</p>" +
                        "   <audio id='" + id + "' src='" + url + "' title='" + title + "' controls='controls'></audio>" +
                        "</div>";
                    return { 'id': supportFormats.Audio.id, 'formats': supportFormats.Audio.formats, 'tag': tag };
                }
                else{                    
                    var tag = "<img id='" + id + "' src='" + url + "' alt='" + title + "' />";
                    return { 'id': supportFormats.Image.id, 'formats': supportFormats.Image.formats, 'tag': tag };
                }
            },

            // Agrega un recurso a la galeria y, de forma opcional, agraga el thumbail correspondiente.
            // @param listItem - Lista de recursos que van a ser agregados. Puede ser un jQuery object o un string of html.
            // @param {Boolean} thumbExists - Especifica si el thumb existe y si debe ser agregado.
            // @param {Boolean} insert - Especifica si el recurso debe ser agregado al final o dentro de la galeria.
            // @param {Integer} position - Posición donde se agregará el recurso. 
            addResource: function (listItem, thumbExists, insert, position) {
                var $li = (typeof listItem === "string") ? $(listItem) : listItem;
                var $aThumb = $li.find('a.thumb');
                var slideUrl = $aThumb.attr('href');
                var title = $aThumb.attr('title');
                var $caption = $li.find('.caption').remove();
                var hash = $aThumb.attr('name');
                var id = $aThumb.attr('id');
                var type = this.setType(id, slideUrl, title);

                // incremento el contador
                resourceCounter++;

                // genero el codigo hash
                if (!hash || allResources['' + hash]) {
                    hash = resourceCounter;
                }

                if (!insert)
                    position = this.data.length;

                var resourceData = {
                    title: title,
                    slideUrl: slideUrl,
                    caption: $caption,
                    hash: hash,
                    gallery: this,
                    index: position,
                    format: type
                };

                // Agrego al recurso al array.
                if (insert) {
                    this.data.splice(position, 0, resourceData);

                    // Actualizo los índices
                    this.updateIndices(position);
                }
                else {
                    this.data.push(resourceData);
                }

                var gallery = this;

                // Agrego el elemento al DOM
                if (!thumbExists) {
                    // Actualizo el thumb y el handler de transición.
                    this.updateThumbs(function () {
                        var $thumbsUl = gallery.find('ul.thumbs');
                        if (insert)
                            $thumbsUl.children(':eq(' + position + ')').before($li);
                        else
                            $thumbsUl.append($li);

                        if (gallery.onResourceAdded)
                            gallery.onResourceAdded(resourceData, $li);
                    });
                }

                // registro el recurso globalmente.
                allResources['' + hash] = resourceData;

                // Seteo los atributos y el evento click.
                $aThumb.attr('rel', 'history')
                    .attr('href', '#' + hash)
                    .removeAttr('name')
                    .click(function (e) {
                        gallery.clickHandler(e, this);
                    });

                return this;
            },

            // Elimino un recurso segun su index en la tabla hash
            // Returns false Si el índice esta fuera de rango.
            removeResourceByIndex: function (index) {
                if (index < 0 || index >= this.data.length)
                    return false;

                var resourceData = this.data[index];
                if (!resourceData)
                    return false;

                this.removeResource(resourceData);

                return true;
            },

            // Elimino un recurso por su códig hash
            removeResourceByHash: function (hash) {
                return $.galleriffic.removeResourceByHash(hash, this);
            },

            // Elimino el recurso pasado por parámetro de la galería.
            removeResource: function (resourceData) {
                var index = resourceData.index;

                // Saco el recurso del array.
                this.data.splice(index, 1);

                delete allResources['' + resourceData.hash];

                // Elimino el recurso del DOM.
                this.updateThumbs(function () {
                    var $li = gallery.find('ul.thumbs')
                        .children(':eq(' + index + ')')
                        .remove();

                    if (gallery.onResourceRemoved)
                        gallery.onResourceRemoved(resourceData, $li);
                });

                // Actualizo los índices.
                this.updateIndices(index);

                return this;
            },

            // Actualiza los índices de todos los recursos empezando por el 
            // índice pasado por parámetro
            updateIndices: function (startIndex) {
                for (i = startIndex; i < this.data.length; i++) {
                    this.data[i].index = i;
                }

                return this;
            },

            // Inicializo los Thumbs
            initializeThumbs: function () {
                this.data = [];
                var gallery = this;

                this.find('ul.thumbs > li').each(function (i) {
                    $(this).dblclick(function (event){ 
                        var res = $(this).find('img, audio, video');
                        var id = $(res).attr('id');
                        var src = $(res).attr('src');
                        var title = ($(res).is('img'))? $(res).attr('alt') : $(res).attr('title');
                        gallery.onDoubleClick(id, src, title);
                        event.preventDefault();
                    });

                    gallery.addResource($(this), true, false);
                });

                return this;
            },

            isPreloadComplete: false,

            // Inicializo el precargador de recursos.
            preloadInit: function () {
                if (this.preloadAhead == 0) return this;

                this.preloadStartIndex = this.currentResource.index;
                var nextIndex = this.getNextIndex(this.preloadStartIndex);
                return this.preloadRecursive(this.preloadStartIndex, nextIndex);
            },

            // Changes the location in the gallery the preloader should work
            // @param {Integer} index The index of the resource where the preloader should restart at.
            preloadRelocate: function (index) {
                // By changing this startIndex, the current preload script will restart
                this.preloadStartIndex = index;
                return this;
            },

            // Recursive function that performs the resource preloading
            // @param {Integer} startIndex The index of the first resource the current preloader started on.
            // @param {Integer} currentIndex The index of the current resource to preload.
            preloadRecursive: function (startIndex, currentIndex) {
                // Check if startIndex has been relocated
                if (startIndex != this.preloadStartIndex) {
                    var nextIndex = this.getNextIndex(this.preloadStartIndex);
                    return this.preloadRecursive(this.preloadStartIndex, nextIndex);
                }

                var gallery = this;

                // Now check for preloadAhead count
                var preloadCount = currentIndex - startIndex;
                if (preloadCount < 0)
                    preloadCount = this.data.length - 1 - startIndex + currentIndex;
                if (this.preloadAhead >= 0 && preloadCount > this.preloadAhead) {
                    // Do this in order to keep checking for relocated start index
                    setTimeout(function () { gallery.preloadRecursive(startIndex, currentIndex); }, 500);
                    return this;
                }

                var resourceData = this.data[currentIndex];
                if (!resourceData)
                    return this;

                // If already loaded, continue
                if (resourceData.resource)
                    return this.preloadNext(startIndex, currentIndex);
                
                resourceData.resource = resourceData.format.tag;

                return this;
            },

            // Called by preloadRecursive in order to preload the next resource after the previous has loaded.
            // @param {Integer} startIndex The index of the first resource the current preloader started on.
            // @param {Integer} currentIndex The index of the current resource to preload.
            preloadNext: function (startIndex, currentIndex) {
                var nextIndex = this.getNextIndex(currentIndex);
                if (nextIndex == startIndex) {
                    this.isPreloadComplete = true;
                } else {
                    // Use setTimeout to free up thread
                    var gallery = this;
                    setTimeout(function () { gallery.preloadRecursive(startIndex, nextIndex); }, 100);
                }

                return this;
            },

            // Safe way to get the next resource index relative to the current resource.
            // If the current resource is the last, returns 0
            getNextIndex: function (index) {
                var nextIndex = index + 1;
                if (nextIndex >= this.data.length)
                    nextIndex = 0;
                return nextIndex;
            },

            // Safe way to get the previous resource index relative to the current resource.
            // If the current resource is the first, return the index of the last resource in the gallery.
            getPrevIndex: function (index) {
                var prevIndex = index - 1;
                if (prevIndex < 0)
                    prevIndex = this.data.length - 1;
                return prevIndex;
            },

            // Advances the gallery to the next resource.
            // @param {Boolean} bypassHistory Specifies whether to delegate navigation to the history plugin when history is enabled.  
            next: function (bypassHistory) {
                this.gotoIndex(this.getNextIndex(this.currentResource.index), bypassHistory);
                return this;
            },

            // Navigates to the previous resource in the gallery.
            // @param {Boolean} bypassHistory Specifies whether to delegate navigation to the history plugin when history is enabled.
            previous: function (bypassHistory) {
                this.gotoIndex(this.getPrevIndex(this.currentResource.index), bypassHistory);
                return this;
            },

            // Navigates to the next page in the gallery.
            // @param {Boolean} bypassHistory Specifies whether to delegate navigation to the history plugin when history is enabled.
            nextPage: function (bypassHistory) {
                var page = this.getCurrentPage();
                var lastPage = this.getNumPages() - 1;
                if (page < lastPage) {
                    var startIndex = page * this.numThumbs;
                    var nextPage = startIndex + this.numThumbs;
                    this.gotoIndex(nextPage, bypassHistory);
                }

                return this;
            },

            // Navigates to the previous page in the gallery.
            // @param {Boolean} bypassHistory Specifies whether to delegate navigation to the history plugin when history is enabled.
            previousPage: function (bypassHistory) {
                var page = this.getCurrentPage();
                if (page > 0) {
                    var startIndex = page * this.numThumbs;
                    var prevPage = startIndex - this.numThumbs;
                    this.gotoIndex(prevPage, bypassHistory);
                }

                return this;
            },

            // Navigates to the resource at the specified index in the gallery
            // @param {Integer} index The index of the resource in the gallery to display.
            // @param {Boolean} bypassHistory Specifies whether to delegate navigation to the history plugin when history is enabled.
            gotoIndex: function (index, bypassHistory) {
                if (index < 0) index = 0;
                else if (index >= this.data.length) index = this.data.length - 1;

                var resourceData = this.data[index];

                if (!bypassHistory && this.enableHistory)
                    $.historyLoad(String(resourceData.hash));  // At the moment, historyLoad only accepts string arguments
                else
                    this.gotoResource(resourceData);

                return this;
            },

            // This function is garaunteed to be called anytime a gallery slide changes.
            // @param {Object} resourceData An object holding the resource metadata of the resource to navigate to.
            gotoResource: function (resourceData) {
                var index = resourceData.index;

                if (this.onSlideChange)
                    this.onSlideChange(this.currentResource.index, index);

                this.currentResource = resourceData;
                this.preloadRelocate(index);

                this.refresh();

                return this;
            },

            // Returns the default transition duration value.  The value is halved when not
            // performing a synchronized transition.
            // @param {Boolean} isSync Specifies whether the transitions are synchronized.
            getDefaultTransitionDuration: function (isSync) {
                if (isSync)
                    return this.defaultTransitionDuration;
                return this.defaultTransitionDuration / 2;
            },

            // Rebuilds the slideshow resource and controls and performs transitions
            refresh: function () {
                var resourceData = this.currentResource;
                if (!resourceData)
                    return this;

                var index = resourceData.index;

                // Update Controls
                if (this.$controlsContainer) {
                    this.$controlsContainer
                        .find('a.prev').attr('href', '#' + this.data[this.getPrevIndex(index)].hash).end()
                        .find('a.next').attr('href', '#' + this.data[this.getNextIndex(index)].hash);
                }

                var previousSlide = this.$resourceContainer.find('span.current').addClass('previous').removeClass('current');
                var previousCaption = 0;

                if (this.$captionContainer) {
                    previousCaption = this.$captionContainer.find('span.current').addClass('previous').removeClass('current');
                }

                // Perform transitions simultaneously if syncTransitions is true and the next resource is already preloaded
                var isSync = this.syncTransitions && resourceData.resource;

                // Flag we are transitioning
                var isTransitioning = true;
                var gallery = this;

                var transitionOutCallback = function () {
                    // Flag that the transition has completed
                    isTransitioning = false;

                    // Remove the old slide
                    previousSlide.remove();

                    // Remove old caption
                    if (previousCaption)
                        previousCaption.remove();

                    if (!isSync) {
                        if (resourceData.resource && resourceData.hash == gallery.data[gallery.currentResource.index].hash) {
                            gallery.buildResource(resourceData, isSync);
                        } else {
                            // Show loading container
                            if (gallery.$loadingContainer) {
                                gallery.$loadingContainer.show();
                            }
                        }
                    }
                };

                if (previousSlide.length == 0) {
                    // For the first slide, the previous slide will be empty, so we will call the callback immediately
                    transitionOutCallback();
                } else {
                    if (this.onTransitionOut) {
                        this.onTransitionOut(previousSlide, previousCaption, isSync, transitionOutCallback);
                    } else {
                        previousSlide.fadeTo(this.getDefaultTransitionDuration(isSync), 0.0, transitionOutCallback);
                        if (previousCaption)
                            previousCaption.fadeTo(this.getDefaultTransitionDuration(isSync), 0.0);
                    }
                }

                // Go ahead and begin transitioning in of next resource
                if (isSync)
                    this.buildResource(resourceData, isSync);

                if (!resourceData.resource) {
                    resourceData.resource = resourceData.format.tag;

                    if (!isTransitioning && resourceData.hash == gallery.data[gallery.currentResource.index].hash) {
                        gallery.buildResource(resourceData, isSync);
                    }
                }

                // This causes the preloader (if still running) to relocate out from the currentIndex
                this.relocatePreload = true;

                return this.syncThumbs();
            },

            // Called by the refresh method after the previous resource has been transitioned out or at the same time
            // as the out transition when performing a synchronous transition.
            // @param {Object} resourceData An object holding the resource metadata of the resource to build.
            // @param {Boolean} isSync Specifies whether the transitions are synchronized.
            buildResource: function (resourceData, isSync) {
                var gallery = this;
                var nextIndex = this.getNextIndex(resourceData.index);

                // Construct new hidden span for the resource
                this.$resourceContainer.empty();
                if (resourceData.format.id == supportFormats.Image.id){
                    var newSlide = this.$resourceContainer.append('<a class="image-advance-link" rel="history" href="#' + this.data[nextIndex].hash + '" title="' + resourceData.title + '"></a>');
                    newSlide.find('a').append(resourceData.resource)
                                      .click(function (e) { gallery.clickHandler(e, this); });
                }
                else if (resourceData.format.id == supportFormats.Audio.id){
                    var newSlide = this.$resourceContainer.append('<a class="audio-advance-link" rel="history" href="#' + this.data[nextIndex].hash + '" title="' + resourceData.title + '">' + resourceData.resource + '</a>');
                }
                else if (resourceData.format.id == supportFormats.Video.id){
                    var newSlide = this.$resourceContainer.append('<a class="video-advance-link" rel="history" href="#' + this.data[nextIndex].hash + '" title="' + resourceData.title + '">' + resourceData.resource + '</a>');
                }
                else
                    this.$resourceContainer.append('<p>No se pudo leer el archivo.</p>');
                
                var newCaption = 0;
                if (this.$captionContainer) {
                    // Construct new hidden caption for the resource
                    this.$captionContainer.empty();
                    newCaption = this.$captionContainer.append(resourceData.caption);
                }

                // Hide the loading conatiner
                if (this.$loadingContainer) {
                    this.$loadingContainer.hide();
                }

                // Transition in the new resource
                if (this.onTransitionIn) {
                    this.onTransitionIn(newSlide, newCaption, isSync);
                } else {
                    newSlide.fadeTo(this.getDefaultTransitionDuration(isSync), 1.0);
                    if (newCaption)
                        newCaption.fadeTo(this.getDefaultTransitionDuration(isSync), 1.0);
                }

                if (this.isSlideshowRunning) {
                    if (this.slideshowTimeout)
                        clearTimeout(this.slideshowTimeout);

                    this.slideshowTimeout = setTimeout(function () { gallery.ssAdvance(); }, this.delay);
                }

                return this;
            },

            // Returns the current page index that should be shown for the currentResource
            getCurrentPage: function () {
                return Math.floor(this.currentResource.index / this.numThumbs);
            },

            // Applies the selected class to the current resource's corresponding thumbnail.
            // Also checks if the current page has changed and updates the displayed page of thumbnails if necessary.
            syncThumbs: function () {
                var page = this.getCurrentPage();
                if (page != this.displayedPage)
                    this.updateThumbs();

                // Remove existing selected class and add selected class to new thumb
                var $thumbs = this.find('ul.thumbs').children();
                $thumbs.filter('.selected').removeClass('selected');
                $thumbs.eq(this.currentResource.index).addClass('selected');

                return this;
            },

            // Performs transitions on the thumbnails container and updates the set of
            // thumbnails that are to be displayed and the navigation controls.
            // @param {Delegate} postTransitionOutHandler An optional delegate that is called after
            // the thumbnails container has transitioned out and before the thumbnails are rebuilt.
            updateThumbs: function (postTransitionOutHandler) {
                var gallery = this;
                var transitionOutCallback = function () {
                    // Call the Post-transition Out Handler
                    if (postTransitionOutHandler)
                        postTransitionOutHandler();

                    gallery.rebuildThumbs();

                    // Transition In the thumbsContainer
                    if (gallery.onPageTransitionIn)
                        gallery.onPageTransitionIn();
                    else
                        gallery.show();
                };

                // Transition Out the thumbsContainer
                if (this.onPageTransitionOut) {
                    this.onPageTransitionOut(transitionOutCallback);
                } else {
                    this.hide();
                    transitionOutCallback();
                }

                return this;
            },

            // Updates the set of thumbnails that are to be displayed and the navigation controls.
            rebuildThumbs: function () {
                var needsPagination = this.data.length > this.numThumbs;

                // Rebuild top pager
                if (this.enableTopPager) {
                    var $topPager = this.find('div.top');
                    if ($topPager.length == 0)
                        $topPager = this.prepend('<div class="top pagination"></div>').find('div.top');
                    else
                        $topPager.empty();

                    if (needsPagination)
                        this.buildPager($topPager);
                }

                // Rebuild bottom pager
                if (this.enableBottomPager) {
                    var $bottomPager = this.find('div.bottom');
                    if ($bottomPager.length == 0)
                        $bottomPager = this.append('<div class="bottom pagination"></div>').find('div.bottom');
                    else
                        $bottomPager.empty();

                    if (needsPagination)
                        this.buildPager($bottomPager);
                }

                var page = this.getCurrentPage();
                var startIndex = page * this.numThumbs;
                var stopIndex = startIndex + this.numThumbs - 1;
                if (stopIndex >= this.data.length)
                    stopIndex = this.data.length - 1;

                // Show/Hide thumbs
                var $thumbsUl = this.find('ul.thumbs');
                $thumbsUl.find('li').each(function (i) {
                    var $li = $(this);
                    if (i >= startIndex && i <= stopIndex) {
                        $li.show();
                    } else {
                        $li.hide();
                    }
                });

                this.displayedPage = page;

                // Remove the noscript class from the thumbs container ul
                $thumbsUl.removeClass('noscript');

                return this;
            },

            // Returns the total number of pages required to display all the thumbnails.
            getNumPages: function () {
                return Math.ceil(this.data.length / this.numThumbs);
            },

            // Rebuilds the pager control in the specified matched element.
            // @param {jQuery} pager A jQuery element set matching the particular pager to be rebuilt.
            buildPager: function (pager) {
                var gallery = this;
                var numPages = this.getNumPages();
                var page = this.getCurrentPage();
                var startIndex = page * this.numThumbs;
                var pagesRemaining = this.maxPagesToShow - 1;

                var pageNum = page - Math.floor((this.maxPagesToShow - 1) / 2) + 1;
                if (pageNum > 0) {
                    var remainingPageCount = numPages - pageNum;
                    if (remainingPageCount < pagesRemaining) {
                        pageNum = pageNum - (pagesRemaining - remainingPageCount);
                    }
                }

                if (pageNum < 0) {
                    pageNum = 0;
                }

                // Prev Page Link
                if (page > 0) {
                    var prevPage = startIndex - this.numThumbs;
                    pager.append('<a rel="history" href="#' + this.data[prevPage].hash + '" title="' + this.prevPageLinkText + '">' + this.prevPageLinkText + '</a>');
                }

                // Create First Page link if needed
                if (pageNum > 0) {
                    this.buildPageLink(pager, 0, numPages);
                    if (pageNum > 1)
                        pager.append('<span class="ellipsis">&hellip;</span>');

                    pagesRemaining--;
                }

                // Page Index Links
                while (pagesRemaining > 0) {
                    this.buildPageLink(pager, pageNum, numPages);
                    pagesRemaining--;
                    pageNum++;
                }

                // Create Last Page link if needed
                if (pageNum < numPages) {
                    var lastPageNum = numPages - 1;
                    if (pageNum < lastPageNum)
                        pager.append('<span class="ellipsis">&hellip;</span>');

                    this.buildPageLink(pager, lastPageNum, numPages);
                }

                // Next Page Link
                var nextPage = startIndex + this.numThumbs;
                if (nextPage < this.data.length) {
                    pager.append('<a rel="history" href="#' + this.data[nextPage].hash + '" title="' + this.nextPageLinkText + '">' + this.nextPageLinkText + '</a>');
                }

                pager.find('a').click(function (e) {
                    gallery.clickHandler(e, this);settings
                });

                return this;
            },

            // Builds a single page link within a pager.  This function is called by buildPager
            // @param {jQuery} pager A jQuery element set matching the particular pager to be rebuilt.
            // @param {Integer} pageNum The page number of the page link to build.
            // @param {Integer} numPages The total number of pages required to display all thumbnails.
            buildPageLink: function (pager, pageNum, numPages) {
                var pageLabel = pageNum + 1;
                var currentPage = this.getCurrentPage();
                if (pageNum == currentPage)
                    pager.append('<span class="current">' + pageLabel + '</span>');
                else if (pageNum < numPages) {
                    var resourceIndex = pageNum * this.numThumbs;
                    pager.append('<a rel="history" href="#' + this.data[resourceIndex].hash + '" title="' + pageLabel + '">' + pageLabel + '</a>');
                }

                return this;
            }
        });

        // Now initialize the gallery
        $.extend(this, defaults, settings);

        // Verify the history plugin is available
        if (this.enableHistory && !$.historyInit)
            this.enableHistory = false;

        // Select containers
        if (this.resourceContainerSel) this.$resourceContainer = $(this.resourceContainerSel);
        if (this.captionContainerSel) this.$captionContainer = $(this.captionContainerSel);
        if (this.loadingContainerSel) this.$loadingContainer = $(this.loadingContainerSel);

        // Initialize the thumbails
        this.initializeThumbs();

        if (this.maxPagesToShow < 3)
            this.maxPagesToShow = 3;

        this.displayedPage = -1;
        this.currentResource = this.data[0];
        var gallery = this;

        // Hide the loadingContainer
        if (this.$loadingContainer)
            this.$loadingContainer.hide();

        // Setup controls
        if (this.controlsContainerSel) {
            this.$controlsContainer = $(this.controlsContainerSel).empty();

            if (this.renderNavControls) {
                this.$controlsContainer
                    .append('<a class="prev" rel="history" title="' + this.prevLinkText + '">' + this.prevLinkText + '</a><a class="next" rel="history" title="' + this.nextLinkText + '">' + this.nextLinkText + '</a>')
                    .find('a')
                    .click(function (e) {
                        gallery.clickHandler(e, this);
                    });
            }
        }

        var initFirstResource = !this.enableHistory || !location.hash;
        if (this.enableHistory && location.hash) {
            var hash = $.galleriffic.normalizeHash(location.hash);
            var resourceData = allResources[hash];
            if (!resourceData)
                initFirstResource = true;
        }

        // Setup gallery to show the first resource
        if (initFirstResource)
            this.gotoIndex(-1, true);

        // Setup Keyboard Navigation
        if (this.enableKeyboardNavigation) {
            $(document).keydown(function (e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                switch (key) {
                    case 33: // Page Up
                        gallery.previousPage();
                        e.preventDefault();
                        break;
                    case 34: // Page Down
                        gallery.nextPage();
                        e.preventDefault();
                        break;
                    case 35: // End
                        gallery.gotoIndex(gallery.data.length - 1);
                        e.preventDefault();
                        break;
                    case 36: // Home
                        gallery.gotoIndex(0);
                        e.preventDefault();
                        break;
                }
            });
        }

        // Auto start the slideshow
        if (this.autoStart)
            this.play();

        // Kickoff resource Preloader after 1 second
        setTimeout(function () { gallery.preloadInit(); }, 1000);

        return this;
    };
})(jQuery);
