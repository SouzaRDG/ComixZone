using System.Collections.Generic;
using System;
using ComixZone.Classes;
using System.Linq;

namespace ComixZone
{
    class Program
    {
        static AutorRepositorio repositorioAutor = new AutorRepositorio();
        static QuadrinhoRepositorio repositorioQuadrinho = new QuadrinhoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
                        ListarAutor();
						break;
					case "2":
						InserirAutor();
						break;
					case "3":
						AtualizarAutor();
						break;
					case "4":
						ExcluirAutor();
						break;
					case "5":
						VisualizarAutor();
						break;
                    case "6":
						ListarQuadrinho();
						break;
					case "7":
						InserirQuadrinho();
						break;
					case "8":
						AtualizarQuadrinho();
						break;
					case "9":
						ExcluirQuadrinho();
						break;
					case "0":
						VisualizarQuadrinho();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

            Console.WriteLine("\nObrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ListarAutor()
		{
			Console.WriteLine("\nLista de Autores");

			var lista = repositorioAutor.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("\nNenhum autor cadastrado.");
				return;
			}

			foreach (var autor in lista)
			{
                var excluido = autor.retornaExcluido();
                
				if(!autor.retornaExcluido())Console.WriteLine("#ID {0}: - {1}", autor.retornaId(), autor.retornaNome());
			}
		}

        private static void ListarQuadrinho()
		{
			Console.WriteLine("\nLista de Quadrinhos");

			var lista = repositorioQuadrinho.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("\nNenhum autor cadastrado.");
				return;
			}

			foreach (var quadrinho in lista)
			{
                var excluido = quadrinho.retornaExcluido();
                
				if(!quadrinho.retornaExcluido())Console.WriteLine("#ID {0}: - {1}", quadrinho.retornaId(), quadrinho.retornaTitulo());
			}
		}

        private static void VisualizarAutor()
		{
			Console.Write("\nDigite o id do autor: ");
			int indice = int.Parse(Console.ReadLine());

			var autor = repositorioAutor.RetornaPorId(indice);

			Console.WriteLine(autor);
		}

        private static void VisualizarQuadrinho()
		{
			Console.Write("\nDigite o id do quadrinho: ");
			int indice = int.Parse(Console.ReadLine());

			var quadrinho = repositorioQuadrinho.RetornaPorId(indice);

			Console.WriteLine(quadrinho);
		}

        private static void ExcluirAutor()
		{
			Console.Write("\nDigite o id do autor: ");
			int indice = int.Parse(Console.ReadLine());

			repositorioAutor.Exclui(indice);
		}

        private static void ExcluirQuadrinho()
		{
			Console.Write("\nDigite o id do quadrinho: ");
			int indice = int.Parse(Console.ReadLine());

			repositorioQuadrinho.Exclui(indice);
		}

        private static void AtualizarAutor()
		{
			Console.Write("\nDigite o id da série: ");
			int indice = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o nome do Autor: ");
			string entradaNome = Console.ReadLine();

            Console.Write("\nDigite a biografia do Autor: ");
			string entradaBio = Console.ReadLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(TipoAutor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAutor), i));
			}
			Console.Write("\nEscolha entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Autor atualizaAutor = new Autor(id: indice,
                                        nome: entradaNome,
										tipoAutor: (TipoAutor)entradaTipo,
										bio: entradaBio);

			repositorioAutor.Atualiza(indice, atualizaAutor);
		}

        private static void AtualizarQuadrinho()
		{
			Console.Write("\nDigite o id da série: ");
			int indice = int.Parse(Console.ReadLine());

			Console.Write("\nDigite o Título do Quadrinho: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(TipoQuadrinho)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoQuadrinho), i));
			}
			Console.Write("\nDigite entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

            Console.Write("\nDigite a sinopse do Quadrinho: ");
			string entradaSinopse = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("\nDigite os gêneros dentre as opções acima, separados por um espaço: ");
			List<string> entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaGenero = new List<Genero>();
            foreach(var str in entradaString)
            {
                entradaListaGenero.Add((Genero)Enum.Parse(typeof(Genero),  str, true));
            }

            foreach (var autor in repositorioAutor.Lista())
			{
				if(autor.retornaTipo() != TipoAutor.Ilustrador)Console.WriteLine("{0}-{1}", autor.retornaId(), autor.retornaNome());
			}
			Console.Write("\nDigite o ID dos roteiristas dentre as opções acima, separados por um espaço: ");
			entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaRoteirista = new List<Autor>();
            foreach(var str in entradaString)
            {
                entradaListaRoteirista.Add(repositorioAutor.RetornaPorId(int.Parse(str)));
            }

            foreach (var autor in repositorioAutor.Lista())
			{
				if(autor.retornaTipo() != TipoAutor.Escritor_e_Roteirista)Console.WriteLine("{0}-{1}", autor.retornaId(), autor.retornaNome());
			}
			Console.Write("\nDigite o ID dos roteiristas dentre as opções acima, separados por um espaço: ");
			entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaIlustrador = new List<Autor>();
            foreach(var str in entradaString)
            {
                entradaListaIlustrador.Add(repositorioAutor.RetornaPorId(int.Parse(str)));
            }

            int entradaVolumes = 0;
            if(entradaTipo != (int)TipoQuadrinho.GraphicNovel && entradaTipo != (int)TipoQuadrinho.Livro)
            {
                Console.Write("\nDigite o numero de volumes: ");
			    entradaVolumes = int.Parse(Console.ReadLine());
            }

            switch(entradaTipo)
            {
                case (int)TipoQuadrinho.Comics: 
                    ComicBook novoComic = new ComicBook(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Atualiza(indice, novoComic);
                    break;
                case (int)TipoQuadrinho.GraphicNovel: 
                    GraphicNovel novoGraphic = new GraphicNovel(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo);
                    repositorioQuadrinho.Atualiza(indice, novoGraphic);
                    break;
                case (int)TipoQuadrinho.Manga: 
                    Manga novoManga = new Manga(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Atualiza(indice, novoManga);
                    break;
                case (int)TipoQuadrinho.Livro: 
                    Livro novoLivro = new Livro(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo);
                    repositorioQuadrinho.Atualiza(indice, novoLivro);
                    break;
                case (int)TipoQuadrinho.LightNovel: 
                    LightNovel novaLN = new LightNovel(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Atualiza(indice, novaLN);
                    break;
            }
		}

        private static void InserirAutor()
		{
			Console.WriteLine("\nInserir novo autor");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(TipoAutor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAutor), i));
			}
			Console.Write("\nDigite entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("\nDigite o nome do autor: ");
			string entradaNome = Console.ReadLine();

			Console.Write("\nDigite a biografia do Autor: ");
			string entradaBio = Console.ReadLine();

			Autor novoAutor = new Autor(id: repositorioAutor.ProximoId(),
										tipoAutor: (TipoAutor)entradaTipo,
										nome: entradaNome,
										bio: entradaBio);

			repositorioAutor.Insere(novoAutor);
		}

        private static void InserirQuadrinho()
		{
			Console.WriteLine("\nInserir novo quadrinho");
            Console.Write("\nDigite o Título do Quadrinho: ");
			string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(TipoQuadrinho)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoQuadrinho), i));
			}
			Console.Write("\nDigite entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

            Console.Write("\nDigite a sinopse do Quadrinho: ");
			string entradaSinopse = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("\nDigite os gêneros dentre as opções acima, separados por um espaço: ");
			List<string> entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaGenero = new List<Genero>();
            foreach(var str in entradaString)
            {
                entradaListaGenero.Add((Genero)Enum.Parse(typeof(Genero),  str, true));
            }

            foreach (var autor in repositorioAutor.Lista())
			{
				if(autor.retornaTipo() != TipoAutor.Ilustrador)Console.WriteLine("{0}-{1}", autor.retornaId(), autor.retornaNome());
			}
			Console.Write("\nDigite o ID dos roteiristas dentre as opções acima, separados por um espaço: ");
			entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaRoteirista = new List<Autor>();
            foreach(var str in entradaString)
            {
                entradaListaRoteirista.Add(repositorioAutor.RetornaPorId(int.Parse(str)));
            }

            foreach (var autor in repositorioAutor.Lista())
			{
				if(autor.retornaTipo() != TipoAutor.Escritor_e_Roteirista)Console.WriteLine("{0}-{1}", autor.retornaId(), autor.retornaNome());
			}
			Console.Write("\nDigite o ID dos ilustradores dentre as opções acima, separados por um espaço: ");
			entradaString = Console.ReadLine().Split(' ').ToList();
            var entradaListaIlustrador = new List<Autor>();
            foreach(var str in entradaString)
            {
                entradaListaIlustrador.Add(repositorioAutor.RetornaPorId(int.Parse(str)));
            }

            int entradaVolumes = 0;
            if(entradaTipo != (int)TipoQuadrinho.GraphicNovel && entradaTipo != (int)TipoQuadrinho.Livro)
            {
                Console.Write("\nDigite o numero de volumes: ");
			    entradaVolumes = int.Parse(Console.ReadLine());
            }

            switch(entradaTipo)
            {
                case (int)TipoQuadrinho.Comics: 
                    ComicBook novoComic = new ComicBook(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Insere(novoComic);
                    break;
                case (int)TipoQuadrinho.GraphicNovel: 
                    GraphicNovel novoGraphic = new GraphicNovel(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo);
                    repositorioQuadrinho.Insere(novoGraphic);
                    break;
                case (int)TipoQuadrinho.Manga: 
                    Manga novoManga = new Manga(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Insere(novoManga);
                    break;
                case (int)TipoQuadrinho.Livro: 
                    Livro novoLivro = new Livro(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo);
                    repositorioQuadrinho.Insere(novoLivro);
                    break;
                case (int)TipoQuadrinho.LightNovel: 
                    LightNovel novaLN = new LightNovel(id: repositorioQuadrinho.ProximoId(),
										sinopse: entradaSinopse,
										titulo: entradaTitulo,
										ano: entradaAno,
										generos: entradaListaGenero,
                                        idRoteiristas: entradaListaRoteirista,
                                        idIlustradores: entradaListaIlustrador,
                                        tipoQuadrinho: (TipoQuadrinho)entradaTipo,
                                        numeroDeVolumes: entradaVolumes);
                    repositorioQuadrinho.Insere(novaLN);
                    break;
            }
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("\n\n");
			Console.WriteLine("ComixZone a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("  --_--_--_--_--_--");
			Console.WriteLine("1- Listar autores");
			Console.WriteLine("2- Inserir novo autor");
			Console.WriteLine("3- Atualizar autor");
			Console.WriteLine("4- Excluir autor");
			Console.WriteLine("5- Visualizar autor");
            Console.WriteLine("  --_--_--_--_--_--");
            Console.WriteLine("6- Listar quadrinhos");
			Console.WriteLine("7- Inserir novo quadrinho");
			Console.WriteLine("8- Atualizar quadrinho");
			Console.WriteLine("9- Excluir quadrinho");
			Console.WriteLine("0- Visualizar quadrinho");
            Console.WriteLine("  --_--_--_--_--_--");
            Console.WriteLine("C- Busca por Tipo de Quadrinho");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine("\n\n");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
