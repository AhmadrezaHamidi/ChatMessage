using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.UserAggregate;


public class CustomerAddress : ValueObject<UserId>
{
  public string City { get;private set; }
  public string Strret { get; private set; }
  public string Address { get;private set; }
  public string PostalCode { get;private set; }
  protected override bool EqualsCore(UserId other)
  {
    throw new NotImplementedException();
  }

  protected override int GetHashCodeCore()
  {
    throw new NotImplementedException();
  }
}
