using FlexiSourceTestApp.Controllers;
using FlexiSourceTestApp.Service;

namespace FlexiSourceTestApp.Test.Controller
{
    public static class ControllerGenerator
    {
        public static TextController GetTextController(ITextService service) => new TextController(service);
    }
}