using HtmlAgilityPack;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SignHere.Test.Utility.Extractor;

public class SignatureClient
{
    private readonly HttpClient httpClient;

    public SignatureClient()
    {
        httpClient = new HttpClient();
    }

    public async Task<HtmlDocument> GetAsync(string uri)
    {
        var response = await httpClient.GetAsync(uri);

        using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        using var streamReader = new StreamReader(responseStream);

        var document = new HtmlDocument();
        document.LoadHtml(await streamReader.ReadToEndAsync().ConfigureAwait(false));

        return document;
    }
}