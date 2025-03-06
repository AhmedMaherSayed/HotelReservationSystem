using AutoMapper;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.AuthenticationViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper) : ControllerBase
    {
        [HttpPost("SignIn")]
        public async Task<ResponseViewModel<bool>> SignInAsync(RegisterViewModel registerViewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                    return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, $"{ModelState}");

                var entity = mapper.Map<IdentityUser>(registerViewModel);

                var result = await userManager.CreateAsync(entity, registerViewModel.Password);

                if (!result.Succeeded)
                    return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, $"{result.Errors}");

                return ResponseViewModel<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest);
            }
        }

        [HttpPatch("ChangePassword")]
        public async Task<ResponseViewModel<bool>> ChangePasswordAsync(ChangePasswordViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest);

                var entity = await userManager.FindByEmailAsync(viewModel.Email);

                if (entity is null)
                    return ResponseViewModel<bool>.Failure(ErrorCode.NotFound);

                var result = await userManager.ChangePasswordAsync(entity, viewModel.OldPassword, viewModel.NewPassword);

                if (!result.Succeeded)
                    return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, $"{result.Errors}");

                return ResponseViewModel<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, message: $"{ex.Message}");
            }

        }
    }
    }
