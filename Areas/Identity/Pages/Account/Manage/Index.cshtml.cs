using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using COREDemo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace COREDemo.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<COREDemoUser> _userManager;
        private readonly SignInManager<COREDemoUser> _signInManager;

        public IndexModel(
            UserManager<COREDemoUser> userManager,
            SignInManager<COREDemoUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
             public DateTime DOB { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "State/Province")]
            public string State { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "ZIP/Postal Code")]
            public string ZipCode { get; set; }

            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "SSN")]
            public string SSN { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Insurance Company")]
            public string InsCompany { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Insurance Policy #")]
            public string InsPolicyNo { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Primary Doctor")]
            public string Doctor { get; set; }

            [Phone]
            [DataType(DataType.Text)]
            [Display(Name = "Primary Doctor Phone Number")]
            public string DoctorPhone { get; set; }

            [DataType(DataType.MultilineText)]
            [Display(Name = "Additional Information")]
            public string AdditionalInfo { get; set; }
        }

        private async Task LoadAsync(COREDemoUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                StreetAddress = user.StreetAddress,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode,
                PhoneNumber = phoneNumber,
                SSN = user.SSN,
                InsCompany = user.InsCompany,
                InsPolicyNo = user.InsPolicyNo,
                Doctor = user.Doctor,
                DoctorPhone = user.DoctorPhone,
                AdditionalInfo = user.AdditionalInfo
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if (Input.DOB != user.DOB)
            {
                user.DOB = Input.DOB;
            }
            if (Input.StreetAddress != user.StreetAddress)
            {
                user.StreetAddress = Input.StreetAddress;
            }
            if (Input.City != user.City)
            {
                user.City = Input.City;
            }
            if (Input.State != user.State)
            {
                user.State = Input.State;
            }
            if (Input.ZipCode != user.ZipCode)
            {
                user.ZipCode = Input.ZipCode;
            }
            if (Input.SSN != user.SSN)
            {
                user.SSN = Input.SSN;
            }
            if (Input.InsCompany != user.InsCompany)
            {
                user.InsCompany = Input.InsCompany;
            }
            if (Input.InsPolicyNo != user.InsPolicyNo)
            {
                user.InsPolicyNo = Input.InsPolicyNo;
            }
            if (Input.Doctor != user.Doctor)
            {
                user.Doctor = Input.Doctor;
            }
            if (Input.DoctorPhone != user.DoctorPhone)
            {
                user.DoctorPhone = Input.DoctorPhone;
            }
            if (Input.AdditionalInfo != user.AdditionalInfo)
            {
                user.AdditionalInfo = Input.AdditionalInfo;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
