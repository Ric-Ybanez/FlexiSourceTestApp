using FlexiSourceTestApp.Common.Request;
using FlexiSourceTestApp.Common.Response;

namespace FlexiSourceTestApp.Service
{
    public interface ITextService
    {
        public StringMatchResponse StringSearch(StringMatchRequest request);
    }
}
