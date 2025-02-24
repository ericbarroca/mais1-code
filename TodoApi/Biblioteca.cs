public class Livro {

    public Livro(string nome, string autor, string editora) {
        Nome = nome;
        Autor = autor;
        Editora = editora;
    }

    public string Nome {get; set;}

    public string Autor {get; set;}

    public string Editora {get; set;}
}

public class Biblioteca {

    private List<Livro> livros;

    public Biblioteca() {
        livros = new List<Livro>() {
            new Livro("A jornada para o oeste", "Anthony C. Yu", "The University of Chicago Press"),
            new Livro("Competição Analítica", "Thomas H. Davenport", "Alta Books"),
            new Livro("Todos os nossos ontens", "Natalia Ginzburg", "Companhia das Letras")
        };
    }

    public List<Livro> ListarLivros() {
        return livros;
    }

    public Livro BuscarLivro(string nome) {

        return livros.SingleOrDefault(l=>l.Nome==nome);
    }

public void Upsert(Livro livro) {

    var livroExistente = BuscarLivro(livro.Nome);

    if (livroExistente is null) {
        livros.Add(livro);
        return;
    }

    livroExistente.Autor = livro.Autor;
    livroExistente.Editora = livro.Editora;
    livroExistente.Nome = livro.Nome;

    }

public bool Delete(string nome){
    if(nome == null) {
        return false;
    }
    return true;
}

}