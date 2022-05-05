using SignHere.Database;
using SignHere.Test.Utility.Extractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace SignHere.Test.Utility
{
    public static class FileSignaturesNetCrawler
    {
        public static async Task<List<Signature>> GetSignatures()
        {
            var results = new List<Signature>();

            var client = new SignatureClient();
            var document = await client.GetAsync("https://filesignatures.net/index.php?page=all");

            int.TryParse(document.DocumentNode.SelectSingleNode("//select[@name='pagejump']/option[last()]").InnerText.Trim(), out int maxPage);
            var links = Enumerable.Range(1, 18).Select(i => $"https://filesignatures.net/index.php?page=all&order=EXT&alpha=&currentpage={i}");

            var getSignatures = new ActionBlock<string>(
                async link =>
                {
                    var document = await client.GetAsync(link);
                    if (document == null) return;

                    var rows = document.DocumentNode.SelectNodes("//table[@id='innerTable']/tr")?.Skip(1).ToList();

                    //<td bgcolor="#f2eded" width="31">

                    //<img id="52" class="login" src="images/img_off.png"></td>
                    //<td bgcolor="#f2eded" width="147"><span id="results"><a href="/index.php?page=search&search=*&mode=EXT">*</a></span></td>
                    //<td bgcolor="#f2eded" width="236"><span id="results"><a href="/index.php?page=search&search=41435344&mode=SIG">41 43 53 44 </a></span></td>
                    //<td bgcolor="#f2eded" width="274">AOL parameter|info files</td>

                    foreach (var row in rows)
                    {
                        var extensionRaw = row.SelectSingleNode(".//td[2]/span/a").InnerText.Trim();
                        var magicBytesRaw = row.SelectSingleNode(".//td[3]/span/a").InnerText.Trim();
                        var descriptionRaw = row.SelectSingleNode(".//td[4]").InnerText.Trim();

                        extensionRaw = Regex.IsMatch(extensionRaw, @"^\d+") ? $"_{extensionRaw}" : extensionRaw;
                        extensionRaw = extensionRaw.Replace(".", "_");

                        var magicBytes = magicBytesRaw.Split(" ").ToList().Select(x => Convert.FromHexString(x)[0]).ToArray();

                        Extension extensionData;
                        if (extensionRaw == "*")
                        {
                            extensionData = Extension.None;
                        }
                        else
                        {
                            Enum.TryParse(extensionRaw, out Extension extensionParsed);
                            extensionData = extensionParsed;
                        }

                        var signature = new Signature()
                        {
                            Extension = extensionData,
                            MagicBytes = magicBytes,
                            Description = descriptionRaw,
                        };

                        results.Add(signature);
                    }
                });

            // Extract

            foreach (var link in links)
            {
                getSignatures.Post(link);
            }

            getSignatures.Complete();
            getSignatures.Completion.Wait();

            return results;
            // Write to JSON

            //List<data> _data = new List<data>();
            //_data.Add(new data()
            //{
            //    Id = 1,
            //    SSN = 2,
            //    Message = "A Message"
            //});

            //string json = JsonSerializer.Serialize(_data);
            //File.WriteAllText(@"D:\path.json", json);
        }
    }
}