using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ExecuteClass>();

[MemoryDiagnoser]
public class ExecuteClass
{
    private List<Pessoa> pessoas;

    [GlobalSetup]
    public void GlobalSetup()
    {
        pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Joao" }, new Pessoa { Nome = "Maria" },
            new Pessoa { Nome = "Pedro" },new Pessoa { Nome = "Giovana" },
            new Pessoa { Nome = "Juliana" }, new Pessoa { Nome = "Carlos" },
            new Pessoa { Nome = "Eduarda" }, new Pessoa { Nome = "Julio" },
        };
    }

    [Benchmark]
    public bool NomesIniciadosComJAny() => 
           pessoas.Any(x => x.Nome.StartsWith("J", StringComparison.OrdinalIgnoreCase));

    [Benchmark]
    public bool NomesIniciadosComJCount() => 
            pessoas.Count(x => x.Nome.StartsWith("J", StringComparison.OrdinalIgnoreCase)) > 0;

    [Benchmark]
    public bool NomesIniciadosComJExist() =>
        pessoas.Exists(x => x.Nome.StartsWith("J", StringComparison.OrdinalIgnoreCase));

}
public class Pessoa
{
    public string Nome { get; set; } 
}
