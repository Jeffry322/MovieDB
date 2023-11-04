using Web.Services;

namespace Web.Interfaces
{
    public interface IUriComposer
    {
        Task<string> ComposePicUri(string picPath, PosterSize size);
    }
}
