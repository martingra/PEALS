var dragElement;

$.fn.setDnD = function (dropEndCallback) {
    var dropEnd = dropEndCallback;

    [ ].forEach.call(this, function (row) {
        row.draggable = true;
        row.addEventListener('dragstart', handleDragStart, false);
        row.addEventListener('dragenter', handleDragEnter, false);
        row.addEventListener('dragover', handleDragOver, false);
        row.addEventListener('dragleave', handleDragLeave, false);
        row.addEventListener('drop', handleDrop, false);
        row.addEventListener('dragend', handleDragEnd, false);
    });

    function handleDragStart(e) {
        dragElement = this;
        e.dataTransfer.effectAllowed = 'move';
        e.dataTransfer.setData('text/html', this.innerHTML);
    }

    function handleDragOver(e) {
        if (e.preventDefault) {
            e.preventDefault();
        }

        e.dataTransfer.dropEffect = 'move';

        return false;
    }

    function handleDragEnter(e) {
        this.classList.add('over');
    }

    function handleDragLeave(e) {
        this.classList.remove('over');
    }

    function handleDrop(e) {
        if (e.stopPropagation) {
            e.stopPropagation();
        }

        if (this != dragElement) {
            var data = e.dataTransfer.getData('text/html');
            dropEnd(this, dragElement);
        }

        return false;
    }

    function handleDragEnd(e) {
        [ ].forEach.call(dragElement, function (row) { row.classList.remove('over'); });
    }
}

$.fn.setFileDnD = function (dropEndCallback, autoload) {
    var dropEnd = dropEndCallback;
    var autoload = autoload;

    [ ].forEach.call(this, function (row) {
        row.addEventListener('dragover', handleDragOver, false);
        row.addEventListener('drop', handleFileSelect, false);
    });

    function handleFileSelect(event) {
        event.stopPropagation();
        event.preventDefault();

        var files = event.dataTransfer.files;
        if (autoload) {
            var reader = new FileReader();
            var content = this;

            reader.onload = (function (theFile) {
                return function (e) {
                    content.src = e.target.result;
                };
            })(files[0]);

            // Leo la imagen como un data URL.
            reader.readAsDataURL(files[0]);
        }
        
        dropEnd(this, files)
    }

    function handleDragOver(event) {
        event.stopPropagation();
        event.preventDefault();
        event.dataTransfer.dropEffect = 'copy'; // Explicitly show this is a copy.
    }
}