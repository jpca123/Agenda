using System;
using System.Collections.Generic;
using Agenda.Dominio;
using System.Linq;

namespace Agenda.Persistencia
{
  public class UserRepository : IUserRepository
  {
    private readonly AppContext _appContext;

    UserRepository(AppContext context){
      _appContext = context;
    }

    int IUserRepository.Add(User _user){
      _appContext.Users.Add(_user);
      return _appContext.SaveChanges();
    }

    User IUserRepository.Get(int id){
      return _appContext.Users.Find(id);
    }

    List<User> IUserRepository.GetAll(){
      return _appContext.Users.ToList();
    }

    IEnumerable<User> IUserRepository.FindByName(string name){
      return _appContext.Users.Where(user => user.name.Contains(name));
    }

    bool IUserRepository.Update(User oldUser){
      User userFind = _appContext.Users.Find(oldUser.id);
      if(userFind == null) return false;

      userFind.name = oldUser.name;
      userFind.last_name = oldUser.last_name;
      userFind.email = oldUser.email;

      return _appContext.SaveChanges() > 0 ? true : false;
    }

    bool IUserRepository.Delete(int id){
      User userFind = _appContext.Users.Find(id);
      if (userFind == null) return false;

      _appContext.Users.Remove(userFind);
      return _appContext.SaveChanges() > 0 ? true : false;
    }

  }
}