using BluDataList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BluDataList.Controllers
{
    public class EmpresaController : Controller
    {
        DAO dao = new DAO();
        // GET: Empresa
        public ActionResult Index()
        {
            var lista = dao.MostrarEmpresas();
            return View(lista);
        }
        public ActionResult Fornecedores(int id, string uf)
        {
            var lista = dao.MostrarFornecedor(id);
            ViewBag.Idempresa = id;
            ViewBag.Estado = uf;
            return View(lista);
        }
        public ActionResult CriaEmpresa()
        {
            return View();
        }
        public ActionResult CriarFornecedor(int idEmpresa, string estado)
        {
            ViewBag.Idempresa = idEmpresa;
            ViewBag.Estado = estado;
            return View();
        }
        public ActionResult SalvaEmpresa(string nome, string cnpj, string UF)
        {
            dao.InserirEmpresa(nome, cnpj, UF);
            return RedirectToAction("Index");
        }
        public ActionResult SalvaFornecedor(string nome, string cnpj, string telefone,string rg, string nascimento, string estado, string id)
        {
            var dados = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            DateTime data = DateTime.Parse(nascimento);
            var contaNumeros = cnpj.Replace(".","").Replace("/","").Replace("-","");
            if (estado == "PR" && contaNumeros.Length == 11)
            {
                var novaData = data.AddYears(+18);
                if (novaData > dados)
                {
                    return View();
                }
            }
            data.ToString("dd/MM/yyyy");
            dao.InserirFornecedor(nome,cnpj,telefone,rg,data.ToString(),estado,id);
            return RedirectToAction("Index");
        }
        public ActionResult DeleEmpresa(int id)
        {
            dao.DeletaEmpresa(id);
            return RedirectToAction("Index");
        } public ActionResult DeleFornecedor(int id)
        {
            dao.DeletaFornecedor(id);
            return RedirectToAction("Index");
        }
    }
}