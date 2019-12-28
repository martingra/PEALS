using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peals.Controllers
{
    public class BusquedaController : Controller
    {
        /// <summary>
        /// Devuelve una partial view con un solo campo que se llena con un autocomplete.
        /// </summary>
        /// <param name="accion">Representa la accion que va a ser llamada por ajax (debe devolver un JSON sin que sea un SELECT * porq se rompe) donde buscar con el autocomplete</param>
        /// <param name="controlador"> Controlador donde esta la accion que devuelve el JSON</param>
        /// <param name="label"> El label es lo que se muestra en el desplegable del autocomplete </param>
        /// <param name="value"> Es lo que queda escrito en el input cuando le apretas enter a la opcion del desplegable</param>
        /// <param name="id"> Es un ID comun y corriente</param>
        /// <returns></returns>
        [ActionName ("Autocomplete")]
        public ActionResult Autocomplete(String accion, String controlador, String label, String value, String idList)
        {
            //armo la ruta para acceder a la accion desde donde se devuelve el JSON
            ViewBag.accion = "/" + controlador + "/" + accion;
            //cargo los valores label, value e id que se utilizan para mostrar los datos en el autocomplete
            ViewBag.label = label;
            ViewBag.value = value;
            ViewBag.id = idList;

            return PartialView();
        }


        /// <summary>
        /// Devuelve una partial view con un solo campo que se llena con un autocomplete. Recibe un id que es el que corresponde a la entidad padre de los elementos a filtrar.
        /// </summary>
        /// <param name="idEntidad">Representa la entidad padre, de la cual quieren obtenerse los hijos. Ejemplo: idInstitucion cuando queremos obtener los cursos de esa institucion</param>
        /// <param name="accion">Representa la accion que va a ser llamada por ajax (debe devolver un JSON sin que sea un SELECT * porq se rompe) donde buscar con el autocomplete</param>
        /// <param name="controlador"> Controlador donde esta la accion que devuelve el JSON</param>
        /// <param name="label"> El label es lo que se muestra en el desplegable del autocomplete </param>
        /// <param name="value"> Es lo que queda escrito en el input cuando le apretas enter a la opcion del desplegable</param>
        /// <param name="id"> Es un ID comun y corriente</param>
        /// <returns></returns>
        [ActionName("AutocompleteConPadre")]
        public ActionResult AutocompleteConPadre(String accion, String controlador, String label, String value, String idList, int idEntidad)
        {
            //armo la ruta para acceder a la accion desde donde se devuelve el JSON
            ViewBag.accion = "/" + controlador + "/" + accion; // + "?idEntidad=" + idEntidad;
            //cargo los valores label, value e id que se utilizan para mostrar los datos en el autocomplete
            ViewBag.label = label;
            ViewBag.value = value;
            ViewBag.id = idList;
            ViewBag.idEntidad = idEntidad;

            return PartialView("AutocompleteConPadre");
        }

        /// <summary>
        /// Devuelve una partial view con un solo campo que se llena con un autocomplete.
        /// </summary>
        /// <param name="accion">Representa la accion que va a ser llamada por ajax (debe devolver un JSON sin que sea un SELECT * porq se rompe) donde buscar con el autocomplete</param>
        /// <param name="controlador"> Controlador donde esta la accion que devuelve el JSON</param>
        /// <param name="label"> El label es lo que se muestra en el desplegable del autocomplete </param>
        /// <param name="value"> Es lo que queda escrito en el input cuando le apretas enter a la opcion del desplegable</param>
        /// <param name="id"> Es un ID comun y corriente</param>
        /// <param name="inputName"> Nombre del input donde se escribe lo q se quiere filtrar</param>
        /// <returns></returns>
        [ActionName("AutocompleteCustomInput")]
        public ActionResult AutocompleteCustomInput(String accion, String controlador, String label, String value, String idList, String inputName)
        {
            //armo la ruta para acceder a la accion desde donde se devuelve el JSON
            ViewBag.accion = "/" + controlador + "/" + accion;
            //cargo los valores label, value e id que se utilizan para mostrar los datos en el autocomplete
            ViewBag.label = label;
            ViewBag.value = value;
            ViewBag.id = idList;
            ViewBag.inputName = inputName;

            return PartialView();
        }

        [ActionName("AutocompleteConPadreCustomInput")]
        public ActionResult AutocompleteConPadreCustomInput(String accion, String controlador, String label, String value, String idList, int idEntidad, String inputName)
        {
            //armo la ruta para acceder a la accion desde donde se devuelve el JSON
            ViewBag.accion = "/" + controlador + "/" + accion;
            //cargo los valores label, value e id que se utilizan para mostrar los datos en el autocomplete
            ViewBag.label = label;
            ViewBag.value = value;
            ViewBag.id = idList;
            ViewBag.inputName = inputName;
            ViewBag.idEntidad = idEntidad;

            return PartialView();
        }

    }
}
