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

#region Documentação de API - Swaggerbucks
https://www.treinaweb.com.br/blog/documentando-uma-asp-net-core-web-api-com-o-swagger
#endregion

#region Criar ENUM Dinamicamente
39

Use o EnumBuilder para criar enums dinamicamente. Isso exigiria o uso de Reflexão.

PASSO 1: CRIANDO ENUM USANDO ASSEMBLY/ENUM BUILDER

// Get the current application domain for the current thread.
AppDomain currentDomain = AppDomain.CurrentDomain;

// Create a dynamic assembly in the current application domain,
// and allow it to be executed and saved to disk.
AssemblyName aName = new AssemblyName("TempAssembly");
AssemblyBuilder ab = currentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);

// Define a dynamic module in "TempAssembly" assembly. For a single-
// module assembly, the module has the same name as the assembly.
ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

// Define a public enumeration with the name "Elevation" and an 
// underlying type of Integer.
EnumBuilder eb = mb.DefineEnum("Elevation", TypeAttributes.Public, typeof(int));

// Define two members, "High" and "Low".
eb.DefineLiteral("Low", 0);
eb.DefineLiteral("High", 1);

// Create the type and save the assembly.
Type finished = eb.CreateType();
ab.Save(aName.Name + ".dll");
PASSO 2: USANDO O ENUM CRIADO

System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFrom("TempAssembly.dll");
System.Type enumTest = ass.GetType("Elevation");
string[] values = enumTest .GetEnumNames();
espero que ajude
#endregion