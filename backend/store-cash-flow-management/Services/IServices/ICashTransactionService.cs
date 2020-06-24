using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface ICashTransactionService
    {
        ICollection getTransactionWithTransactionType(int typeId);

        decimal getTotalCashWithTransactionType(int typeId);


    }
}
