using Microsoft.AspNetCore.Mvc;
using ContatosApp.MVC.Models.Contatos;
using Newtonsoft.Json;
using System.Text;
using ContatosApp.MVC.Models.Errors;
using System.Net.Http.Headers;
using ContatosApp.MVC.Models.Usuarios;
using System.Reflection;

namespace ContatosApp.MVC.Controllers
{
    public class Contatos : Controller
    {
        private string _apiEndpoint = "http://localhost:5058/api";
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(ContatosCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        //serializando os dados da model para o formato JSON
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "Application/json");

                        //enviando uma requisição para o serviço de cadastro de API e pegando a resposta
                        var response = httpClient.PostAsync($"{_apiEndpoint}/contatos/criar", content).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                        }
                        else
                        {
                            //desializando o s dados retornados pela API
                            var result = JsonConvert.DeserializeObject<ErrorResponseViewModel>
                                (response.Content.ReadAsStringAsync().Result);
                            TempData["MensagemErro"] = result.Message;
                        }
                    }

                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Consulta(ContatosConsultaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados da sessão e deserializar estes dados
                    var consulta = JsonConvert.DeserializeObject<UsuarioViewModel>
                        (HttpContext.Session.GetString("USUARIO"));

                    using (var httpClient = new HttpClient())
                    {
                        //adicionando o TOKEN no cabeçalho da requisição
                        httpClient.DefaultRequestHeaders.Authorization
                                = new AuthenticationHeaderValue("Bearer", consulta.AccessToken);
                        var response = httpClient.GetAsync
                            ($"{_apiEndpoint}/contatos").Result;

                        if (response.IsSuccessStatusCode)
                        {
                            //deserializar a lista de tarefas para exibir na página
                            TempData["Contatos"] = JsonConvert.DeserializeObject<List<ContatosViewModel>>
                                (response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Falha ao consultar tarefa";
                        }
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Falha ao consultar";
                }
            }
            return View();
            //}
            //public IActionResult Consulta(ContatosConsultaViewModel model)
            //{
            //    if()
            //    return View();
            //}
        }

        [HttpPost]
        public IActionResult Editar(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        //serializando os dados da model para o formato JSON
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "Application/json");

                        //enviando uma requisição para o serviço de cadastro de API e pegando a resposta
                        var response = httpClient.PutAsync($"{_apiEndpoint}/contatos/editar/",content).Result;

                       // var response = httpClient.PostAsync($"{_apiEndpoint}/contatos/editar/").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            TempData["MensagemSucesso"] = "Contato editado com sucesso";
                            return RedirectToAction("Consulta", "Contatos");
                        }
                        else
                        {
                            //desializando o s dados retornados pela API
                            var result = JsonConvert.DeserializeObject<ErrorResponseViewModel>
                                (response.Content.ReadAsStringAsync().Result);
                            TempData["MensagemErro"] = result.Message;
                        }
                    }

                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(ContatosEditViewModel model)
        {
            try
            {
               // capturar os dados da sessão e deserializar estes dados
                var consulta = JsonConvert.DeserializeObject<UsuarioViewModel>
                    (HttpContext.Session.GetString("USUARIO"));
                using (var httpClient = new HttpClient())
                {
                   // adicionando o TOKEN no cabeçalho da requisição
                    httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", consulta.AccessToken);
                    //enviando uma requisiçao para a consulta do usuario
                    var response = httpClient.GetAsync
                        ($"{_apiEndpoint}/contatos/buscar/{model.Id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                       // deserializar a lista de tarefas para exibir na página
                        var contato= JsonConvert.DeserializeObject<ContatosEditViewModel>
                            (response.Content.ReadAsStringAsync().Result);
                       
                        model.Id = contato.Id;
                        model.Nome = contato.Nome;
                        model.Email = contato.Email;
                        model.Telefone = contato.Telefone;                     


                    }
                    else
                    {
                        TempData["MensagemErro"] = "Falha ao consultar tarefa";
                    }
                }

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Falha ao consultar";
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Excluir(Guid id)
        {

            try
            {
                // capturar os dados da sessão e deserializar estes dados
                var consulta = JsonConvert.DeserializeObject<UsuarioViewModel>
                (HttpContext.Session.GetString("USUARIO"));
                using (var httpClient = new HttpClient())
                {
                    // adicionando o TOKEN no cabeçalho da requisição
                    httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", consulta.AccessToken);
                    //enviando uma requisiçao para a consulta do usuario
                    var response = httpClient.DeleteAsync
                        ($"{_apiEndpoint}/contatos/excluir/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Excluido";
                        return RedirectToAction("Consulta", "Contatos");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Falha ao consultar tarefa";
                    }
                }
            }


            catch (Exception e)
            {
                TempData["MensagemErro"] = "Falha ao consultar";
            }
           
            return View();
        }
    }
}
