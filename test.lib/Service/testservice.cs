using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.lib.Entity;

namespace test.lib.Service
{
    public class testservice
    {
        public List<Control> GetControls()
        {
            try
            {
                using (LocationContext db = new LocationContext())
                {
                    var data =  db.Controls.Where(x => !x.IsDeleted && x.ControlName == "Type").ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return new List<Control>();
            }

        }

        public List<UserLocation> GetOtherLocation()
        {
            try
            {
                using (LocationContext db = new LocationContext())
                {
                    var data = db.UserLocations.ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return new List<UserLocation>();
            }

        }

        public async Task<bool> AddDriverAsync(Driver driver)
        {
            try
            {
                using(LocationContext db = new LocationContext())
                {
                    var control = await db.Controls.Where(x => x.ControlName == "UniqueId").FirstOrDefaultAsync();
                    int id = Convert.ToInt32(control.ControlValue);
                    if(control != null)
                    {
                        driver.UniqueId = "TT" + Convert.ToInt32(control.ControlValue);
                    }
                    await db.AddAsync(driver);
                    await db.SaveChangesAsync();
                    if (control != null)
                    {
                        control.ControlValue = (id + 1).ToString();
                        await db.SaveChangesAsync();
                    }
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
