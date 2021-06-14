using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WebApplication2.Controllers;

namespace WebApplication2
{
    public class AutofacConfig
    {
        public static void Run()
        {
            // 1.建立容器
            var builder = new ContainerBuilder();

            // 2.註冊服務
            //取得目前執行App的Assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 註冊物件
            builder.Register(c => new EMail()).As<IMessageService>();

            // 註冊Controller和ApiController
            builder.RegisterControllers(assembly); // Controller

            // === 3. 由Builder建立容器 ===
            var container = builder.Build();

            // === 4. 把容器設定給DependencyResolver ===
            // Controller
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}