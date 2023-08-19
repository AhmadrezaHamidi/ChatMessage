using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.UserAggregate;
public class UserId : StronglyTypedId<Guid>
{
  public UserId(Guid value) : base(value)
  {
  }
}

//public class ContactInfoId : StronglyTypedId<Guid>
//{
//  public ContactInfoId(Guid value) : base(value)
//  {
//  }
//}


//public class CustomerAddressId : StronglyTypedId<Guid>
//{
//  public CustomerAddressId(Guid value) : base(value)
//  {
//  }
//}
