using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Web.Script.Serialization;

namespace Peals.Controllers
{
    public class CriterioController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        private RecursoController mRecursoController = new RecursoController();

        [HttpPost]
        public JsonResult GetCriterio(int id)
        {
            string xml_path = mDb.criterio_evaluacion.First(x => x.id == id).descripcion;

            System.Xml.XmlDocument xml_criterio = new System.Xml.XmlDocument();
            xml_criterio.LoadXml(xml_path);
            System.Xml.XmlNodeList intervalos = xml_criterio.GetElementsByTagName("intervalo");

            int[] ids = new int[intervalos.Count];
            string[] values = new string[intervalos.Count];
            string[] src = new string[intervalos.Count];

            for (int i = 0; i < intervalos.Count; i++){
                values[i] = intervalos[i].Attributes["value"].Value;
                int id_res = int.Parse(intervalos[i].InnerText);
                ids[i] = id_res;

                if (id_res == -1) src[i] = "";
                else
                {
                    recurso rec = mDb.recurso.FirstOrDefault(x => x.id == id_res);
                    src[i] = (rec != null) ? rec.ruta : "";
                }
            }

            return Json(new { ids = ids, values = values, src = src }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCriterio(string id, string nombre, string intervalos)
        {
            int user_id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            int cri_id = int.Parse(id);

            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(intervalos);

            string xml = "<intervalos>";
            for (int i = 0; i < json.Count; i++)
            {
                string value = json[i].value;
                HttpPostedFileBase file = Request.Files[value];
                int db_id = json[i].db_id;
                int id_recurso = (file != null) ?
                    mRecursoController.GuardarRecurso(file, file.FileName, user_id, ControllerContext, (int)TipoDeRecurso.Imagen).id :
                    db_id;

                xml += string.Format("<intervalo value='{0}'>{1}</intervalo>", json[i].value, id_recurso);
            }

            xml += "</intervalos>";

            criterio_evaluacion criterio = null;
            if (cri_id == -1)
            {
                criterio = new criterio_evaluacion()
                { 
                    nombre = nombre,
                    docente = user_id,
                    descripcion = xml
                };

                mDb.criterio_evaluacion.AddObject(criterio);
            }
            else
            {
                criterio = mDb.criterio_evaluacion.First(x => x.id == cri_id);
                criterio.nombre = nombre;
                criterio.descripcion = xml;

                mDb.ObjectStateManager.ChangeObjectState(criterio, System.Data.EntityState.Modified);
            }

            mDb.SaveChanges();

            cri_id = criterio.id;

            string[] values = new string[] { cri_id.ToString(), nombre };
            return Json(cri_id, JsonRequestBehavior.AllowGet);
        }
    }
}
