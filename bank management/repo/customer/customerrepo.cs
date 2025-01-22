using bank_management.data;
using bank_management.dto;
using bank_management.models;
using Microsoft.EntityFrameworkCore;

namespace bank_management.repo.customer
{
    public class customerrepo : Icustomer
    {
        private readonly AppDbContext _context;
        public customerrepo(AppDbContext context)
        {
            
            _context = context;
        }
        public void addcustomer(getcustomerDto getcustomerDto)
        {
            models.customer customer = new models.customer()
            {
                name = getcustomerDto.name,
                email = getcustomerDto.email,
                phone = getcustomerDto.phone,
                bankcardid = getcustomerDto.bankcardid,
                accounts = getcustomerDto.addaccountdto.Select(x => new models.account()
                {
                    accountnumber = x.accountnumber,
                    balance = x.balance,

                }).ToList(),
                bankcard = new models.bankcard()
                {
                    cardnumber = getcustomerDto.addbankcarddto.cardnumber,
                    customerid = getcustomerDto.bankcardid,
                    expirydate = getcustomerDto.addbankcarddto.expirydate,
                }


            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
           



        public getcustomerDto Get(int id)
        {
            var res = _context.Customers.Include(x => x.accounts).Include(x => x.bankcard).FirstOrDefault(x => x.id == id);
            if (res == null)
            {
                return null;
            }   
            return new getcustomerDto()
            {
                name = res.name,
                email = res.email,
                phone = res.phone,
                bankcardid = res.bankcardid,
                addaccountdto = res.accounts.Select(x => new addaccountdto()
                {
                    accountnumber = x.accountnumber,
                    balance = x.balance,
                }).ToList(),
                addbankcarddto = new addbankcarddto()
                {
                    cardnumber = res.bankcard.cardnumber,
                    expirydate = res.bankcard.expirydate,
                }
            };
        }

        public List<getcustomerDto> Getall()
        {
           var res = _context.Customers.Include(x => x.accounts).Include(x => x.bankcard).ToList();
            return res.Select(x => new getcustomerDto()
            {
                name = x.name,
                email = x.email,
                phone = x.phone,
                bankcardid = x.bankcardid,
                addaccountdto = x.accounts.Select(y => new addaccountdto()
                {
                    accountnumber = y.accountnumber,
                    balance = y.balance,
                }).ToList(),
                addbankcarddto = new addbankcarddto()
                {
                    cardnumber = x.bankcard.cardnumber,
                    expirydate = x.bankcard.expirydate,
                }
            }).ToList();
        }
    }
}
