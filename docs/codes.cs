#region Code to implementation in the hash UniqueKey of ApplicationGroup
using System;
using System.Security.Cryptography;
using System.Text;
					
public class Program
{
	static void Main(string[] args)
    {
        // example:
        // replace-with-desired-secret => 5KZ3D/MuEtYxRNTZ2oY6oHdLdxMZ6x4YxQI2n1v2g7c=

        // replace this with desired secret; could be a randomly generated one of sufficient length like a guid
        var secret = "Master"; // Guid.NewGuid().ToString();
        var hash = Sha256(secret);
        Console.WriteLine($"secret: {secret}");
        Console.WriteLine($"hash: {hash}");
    }

    // source: https://github.com/IdentityServer/IdentityServer4/blob/main/src/IdentityServer4/src/Extensions/HashExtensions.cs
    // IdentityServer4.Models.HashExtensions.Sha256
    static string Sha256(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}
#endregion 

#region FileUpload com React
export class FileUpload extends Component {
    static displayName = FileUpload.name;

    async handleSubmit(e) {
        e.preventDefault();

        const url = 'api/Books';

        const formData = new FormData();
        formData.append('file', this.refs.File.files[0]);

        var book = {
            title: this.refs.Title.value,
            author: this.refs.Author.value,
            language: this.refs.Language.value
        };
        formData.append('metadata', JSON.stringify(book));

        post(url, formData);
    }

    render() {
        return (
            <div>
                <h1>File Upload</h1>
                <form onSubmit={e => this.handleSubmit(e)}>
                    <div className="form-group">
                        <label>Title</label>
                        <input className="form-control" ref="Title" required />
                    </div>
                    <div className="form-group">
                        <label>Author</label>
                        <input className="form-control" ref="Author" required />
                    </div>
                    <div className="form-group">
                        <label>Language</label>
                        <select className="form-control" ref="Language">
                            <option>English</option>
                            <option>German</option>
                            <option>French</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>File</label>
                        <input type="file" className="form-control-file" ref="File" required />
                    </div>
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
            </div>
        );
    }
}
 [HttpPost]
public void PostBook(IFormCollection bookData)
{
    var book = JsonConvert.DeserializeObject<Book>(bookData["metadata"]);

    _bookService.AddBookToDb(book, bookData.Files[0]);
}
#endregion