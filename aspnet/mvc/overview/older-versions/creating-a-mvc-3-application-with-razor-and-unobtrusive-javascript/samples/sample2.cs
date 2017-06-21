using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mvc3Razor.Models {
    public class UserModel {

        [Required]
        [StringLength(6, MinimumLength = 3)]
        [Display(Name = "User Name")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required()]
        public string City { get; set; }

    }

    public class Users {

        public Users() {
            _usrList.Add(new UserModel
            {
                UserName = "BenM",
                FirstName = "Ben",
                LastName = "Miller",
                City = "Seattle"
            });
            _usrList.Add(new UserModel
            {
                UserName = "AnnB",
                FirstName = "Ann",
                LastName = "Beebe",
                City = "Boston"
            });
        }

        public List<UserModel> _usrList = new List<UserModel>();

        public void Update(UserModel umToUpdate) {

            foreach (UserModel um in _usrList) {
                if (um.UserName == umToUpdate.UserName) {
                    _usrList.Remove(um);
                    _usrList.Add(umToUpdate);
                    break;
                }
            }
        }

        public void Create(UserModel umToUpdate) {
            foreach (UserModel um in _usrList) {
                if (um.UserName == umToUpdate.UserName) {
                    throw new System.InvalidOperationException("Duplicat username: " + um.UserName);
                }
            }
            _usrList.Add(umToUpdate);
        }

        public void Remove(string usrName) {

            foreach (UserModel um in _usrList) {
                if (um.UserName == usrName) {
                    _usrList.Remove(um);
                    break;
                }
            }
        }

        public  UserModel GetUser(string uid) {
            UserModel usrMdl = null;

            foreach (UserModel um in _usrList)
                if (um.UserName == uid)
                    usrMdl = um;

            return usrMdl;
        }

    }    
}