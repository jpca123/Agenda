using System;
using System.Collections.Generic;
using Agenda.Dominio;

namespace Agenda.Persistencia
{
  public interface IUserRepository
  {
    int Add(User _user);

    User Get(int id);

    List<User> GetAll();

    IEnumerable<User> FindByName(string name);

    bool Update(User oldUser);

    bool Delete(int id);

  }
}