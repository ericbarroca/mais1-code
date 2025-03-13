// See https://aka.ms/new-console-template for more information

using Libs.Models;
using Libs.Repository;

TutorRepository tutorRepository = new TutorRepository();
PetRepository petRepository = new PetRepository(tutorRepository);

Tutor tutoraAlberta = new Tutor("alberta", DateTime.Now, "rua uranos", 216365698);

tutorRepository.Upsert(tutoraAlberta);

Pet p1 = new Pet("alberto", DateTime.Now, Especie.cachorro,"");
Pet p2 = new Pet("joao", DateTime.Now, Especie.cachorro,"");


tutoraAlberta.UpsertPet(petRepository,p1);
tutoraAlberta.UpsertPet(petRepository,p2);

p2.Nome = "paulo";

tutoraAlberta.UpsertPet(petRepository,p2);

tutoraAlberta.RemovePet(petRepository,p1.ID);



List<Pet> pets = tutoraAlberta.Pets(petRepository);

VacinaRepository vacinaRepo = new VacinaRepository(petRepository);
Vacina vacina1 = new Vacina("raiva", DateTime.Now, DateTime.Now, TimeSpan.FromDays(90), p2.ID);
vacinaRepo.Upsert(vacina1);

Console.ReadLine();
