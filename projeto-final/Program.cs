// See https://aka.ms/new-console-template for more information

using ProjetoFinal.Models;
using ProjetoFinal.Repository;

Pet p1 = new Pet("alberto", DateTime.Now, Especie.cachorro, "");
Pet p2 = new Pet("joao", DateTime.Now, Especie.cachorro, "");

PetRepository repo = new PetRepository();
repo.Upsert(p1);
repo.Upsert(p2);

p2.Nome = "paulo";

repo.Upsert(p2);

repo.Remove(p1.ID);

List<Pet> pets = repo.List();



Tutor tutoraAlberta = new Tutor(repo,"alberta", new Documento(TipoDocumento.RG, 123456789),
 DateTime.Now, "rua uranos", 216365698, new List<int>());

TutorRepository tutorRepository = new TutorRepository(repo);
tutorRepository.Upsert(tutoraAlberta);

tutoraAlberta.AddPet(p1.ID);
tutorRepository.Upsert(tutoraAlberta);

Console.ReadLine();
