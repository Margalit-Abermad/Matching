using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public interface IDonationService
{
    List<DonationsVM> GetList();

    DonationsVM GetById(int Id);

    void Delete(int Id);

    void Update(DonationsVM donationVM);

    void Create(DonationsVM donationVM);
}
