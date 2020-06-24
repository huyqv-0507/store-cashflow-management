using Data.Infrastructures.IRepositories;
using Services.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CashTransactionService : ICashTransactionService
    {
        ICashTransactionRepository _transactionRepo;
        ITransactionTypeRepository _typeTransactionRepo;

        public CashTransactionService(ICashTransactionRepository transactionRepo, ITransactionTypeRepository typeTransactionRepo)
        {
            _transactionRepo = transactionRepo;
            _typeTransactionRepo = typeTransactionRepo;
        }

        public CashTransactionService()
        {

        }
        public ICollection getTransactionWithTransactionType(int typeId)
        {
            if(typeId != null)
            {
                if(_typeTransactionRepo.GetAll().Any(x => x.Id == typeId))
                {
                    var listTransaction = _transactionRepo.GetAll().Where(x => x.TransactionTypeId == typeId).ToList();
                    return listTransaction;
                }
            }
            return null;
        }

        public decimal getTotalCashWithTransactionType(int typeId)
        {
            if (typeId != null)
            {
                if (_typeTransactionRepo.GetAll().Any(x => x.Id == typeId))
                {
                }

            }
            return 0;
        }
    }
}
