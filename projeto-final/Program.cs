// See https://aka.ms/new-console-template for more information

using ProjetoFinal.Models;
using ProjetoFinal.Repository;

TutorRepository tutorRepository = new TutorRepository();
PetRepository petRepository = new PetRepository(tutorRepository);

Tutor tutoraAlberta = new Tutor("alberta", new Documento(TipoDocumento.RG, 123456789),
 DateTime.Now, "rua uranos", 216365698);

tutorRepository.Upsert(tutoraAlberta);

Pet p1 = new Pet("alberto", DateTime.Now, Especie.cachorro,"", tutoraAlberta.Documento);
Pet p2 = new Pet("joao", DateTime.Now, Especie.cachorro,"", tutoraAlberta.Documento);


tutoraAlberta.UpsertPet(petRepository,p1);
tutoraAlberta.UpsertPet(petRepository,p2);

p2.Nome = "paulo";

tutoraAlberta.UpsertPet(petRepository,p2);

tutoraAlberta.RemovePet(petRepository,p1.ID);

List<Pet> pets = tutoraAlberta.Pets(petRepository);

Console.ReadLine();
