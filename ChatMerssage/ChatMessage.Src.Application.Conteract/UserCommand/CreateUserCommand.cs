using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMessage.FramWork.Application;

namespace ChatMessage.Src.Application.Conteract.UserCommand;
public class CreateUserCommand : ICommand
{
  public CreateUserCommand(int age, string? firstName, string? lastName)
  {
    Age = age;
    FirstName = firstName;
    LastName = lastName;
  }

  public int Age { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}
