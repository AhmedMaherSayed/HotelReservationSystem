using AutoMapper.QueryableExtensions;
using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services
{
    public class RoomService
    {
        private readonly IGenericRepository<Room> _genericRepo;
        

        public RoomService(IGenericRepository<Room> genericRepo)
        {
            _genericRepo = genericRepo;

        }
        public async Task<ResponseViewModel<RoomViewModel>> Create(CreateRoomDTO roomDto)
        {
            var room= roomDto.Map<Room>();
            

            if(roomDto.Facilities is not null)
            {
                room.Facilities = new List<RoomFacility>();
                foreach (var facilityId in roomDto.Facilities)
                {
                    var facility = new RoomFacility
                    {
                        FacilityId = facilityId
                    };
                    room.Facilities.Add(facility);
                }
            }

            if(roomDto.Images is not null)
            {
                room.RoomImages = new List<RoomImage>();
                foreach (var image in roomDto.Images)
                {
                    if (image is not null)
                    {
                        var imageUrl = DocumentSettings.UploadImage(image);

                        if (imageUrl is not null)
                        {
                            var roomImage = new RoomImage
                            {
                                ImageURL = imageUrl,
                                CreatedAt = DateTime.Now
                            };
                            room.RoomImages.Add(roomImage);
                        }
                    }
                }
            }
             await _genericRepo.AddAsync(room);
            return ResponseViewModel<Room>.Success(room);
        }
        public async Task<ResponseViewModel<List<RoomResponseDTO>>> GetAll()
        {
          var rooms =  _genericRepo.Get(r=> !r.IsDeleted)
                .Select(r => r.Map<RoomViewModel>()).ToList();
            //var roomDtos = await rooms.Project<RoomResponseDTO>().ToListAsync();
            return ResponseViewModel<List<RoomViewModel>>.Success(rooms);
        }
        public async Task<ResponseViewModel<RoomViewModel>> GetByIdAsync(int id)
        {
            var room = await _genericRepo.Get(x=>x.Id==id)
                .Select(r => r.Map<RoomViewModel>())
                .FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<RoomViewModel>.Failure(ErrorCode.RoomNotFound, "Room not found");
            return ResponseViewModel<RoomViewModel>.Success(room);
        }
        public async Task<ResponseViewModel<RoomViewModel>> UpdateAsync(int id, UpdateRoomDTO roomDto)
        {
            var room = await _genericRepo.Get(x => x.Id == id)
                  .FirstOrDefaultAsync();
            //var room = await _genericRepo.Get(x => x.Id == id)
            //    .Select(r => r.Map<UpdateRoomDTO>())
            //      .FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<RoomViewModel>.Failure(ErrorCode.RoomNotFound,"Room not found");
            //roomDto.Map(room);
            room.Type = roomDto.RoomType;
            room.Status = roomDto.Status;
            room.CurrentPricePerNight = roomDto.CurrentPricePerNight;


            _genericRepo.UpdateInclude(room,nameof(roomDto.RoomType), nameof(roomDto.Status), 
                 nameof(roomDto.CurrentPricePerNight));
            
            
            return ResponseViewModel<RoomViewModel>.Success(room.Map<RoomViewModel>());
        }
        public async Task<ResponseViewModel<string>> DeleteAsync(int id)
        {
            var room = await _genericRepo.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<string>.Failure(ErrorCode.RoomNotFound, "Room not found");

            room.IsDeleted = true;
            _genericRepo.UpdateInclude(room, nameof(room.IsDeleted));
            return ResponseViewModel<string>.Success("Room deleted successfully");
        }
        public async Task<ResponseViewModel<List<RoomViewModel>>> GetAvailableRoomsAsync()
        {
            var availableRooms = await  _genericRepo.Get(r => r.Status == RoomStatus.Available)
                .Select(r => r.Map<RoomViewModel>()).ToListAsync();

            return ResponseViewModel<List<RoomViewModel>>.Success(availableRooms);
        }
    }

}
