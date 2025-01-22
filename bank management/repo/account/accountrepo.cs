using bank_management.data;
using bank_management.dto;
using Microsoft.EntityFrameworkCore;

namespace bank_management.repo.account
{
    public class accountrepo : Iaccountrepo
    {
        private readonly AppDbContext _context;

        public accountrepo(AppDbContext context)
        {
            _context = context;
        }

        public void addaccount(accountadddto accountadddto)
        {
            models.account account = new models.account()
            {
                accountnumber = accountadddto.accountnumber,
                balance = accountadddto.balance,
                customerid = accountadddto.customerid,
                customer = new models.customer()
                {
                    name = accountadddto.dtocustomer.name,
                    email = accountadddto.dtocustomer.email,
                    phone = accountadddto.dtocustomer.phone,
                    bankcardid = accountadddto.dtocustomer.bankcardid,
                    bankcard = new models.bankcard()
                    {
                        cardnumber = accountadddto.dtocustomer.addbankcarddto.cardnumber,
                        expirydate = accountadddto.dtocustomer.addbankcarddto.expirydate,
                    }
                }
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public bool deleteaccount(int id)
        {
            var res = _context.Accounts.FirstOrDefault(x => x.id == id);
            if (res != null)
            {
                _context.Accounts.Remove(res);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public List<dtoaddaccount> Getall()
        {
            var
        }

        public bool updateaccount(int id, updateaccountdto updateaccountdto)
        {
            var res = _context.Accounts.Include(x => x.customer).FirstOrDefault(x => x.id == id);
            if (res != null)
            {
                res.balance = updateaccountdto.balance;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
