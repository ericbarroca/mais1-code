// See https://aka.ms/new-console-template for more information

using ProjetoFinal.Models;
using ProjetoFinal.Repository;

Pet p1 = new Pet("alberto", DateTime.Now, Especie.cachorro, "");
Pet p2 = new Pet("joao", DateTime.Now, Especie.cachorro, "");

PetRepository repo = new PetRepository();
repo.Upsert(p1);
repo.Upsert(p2);

p2.Nome="paulo";

repo.Upsert(p2);

repo.Remove(p1.ID);

List<Pet> pets = repo.List();

Console.ReadLine();

Tutor T5 = new Tutor("alberta", DateTime.Now, "rua uranos", 216365698);
T5.TipoDocumento = DocumentoTutor.CPF;
T5.NumeroDocumento = "157856644542";
