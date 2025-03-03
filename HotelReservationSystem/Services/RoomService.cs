﻿using AutoMapper.QueryableExtensions;
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
        public async  Task<ResponseViewModel<Room>> Create(CreateRoomDTO roomDto)
        {
            var room= roomDto.Map<Room>();
             await _genericRepo.AddAsync(room);
            return ResponseViewModel<Room>.Success(room);
        }
        public async Task<ResponseViewModel<List<RoomResponseDTO>>> GetAll()
        {
          var rooms =  _genericRepo.Get(r=> !r.IsDeleted)
                .Select(r => r.Map<RoomResponseDTO>()).ToList();
            //var roomDtos = await rooms.Project<RoomResponseDTO>().ToListAsync();
            return ResponseViewModel<List<RoomResponseDTO>>.Success(rooms);
        }
        public async Task<ResponseViewModel<RoomResponseDTO>> GetByIdAsync(int id)
        {
            var room = await _genericRepo.Get(x=>x.Id==id)
                .Select(r => r.Map<RoomResponseDTO>())
                .FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<RoomResponseDTO>.Failure(ErrorCode.RoomNotFound, "Room not found");
            return ResponseViewModel<RoomResponseDTO>.Success(room);
        }
        public async Task<ResponseViewModel<RoomResponseDTO>> UpdateAsync(int id, UpdateRoomDTO roomDto)
        {
            var room = await _genericRepo.Get(x => x.Id == id)
                  .FirstOrDefaultAsync();
            //var room = await _genericRepo.Get(x => x.Id == id)
            //    .Select(r => r.Map<UpdateRoomDTO>())
            //      .FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<RoomResponseDTO>.Failure(ErrorCode.RoomNotFound,"Room not found");
            //roomDto.Map(room);
            room.Type = roomDto.RoomType;
            room.Status = roomDto.Status;
            room.CurrentPricePerNight = roomDto.CurrentPricePerNight;


            _genericRepo.UpdateInclude(room,nameof(roomDto.RoomType), nameof(roomDto.Status), 
                 nameof(roomDto.CurrentPricePerNight));
            
            
            return ResponseViewModel<RoomResponseDTO>.Success(room.Map<RoomResponseDTO>());
        }
        public async Task<ResponseViewModel<string>> DeleteAsync(int id)
        {
            var room = await _genericRepo.Get(x => x.Id == id).FirstOrDefaultAsync();
            if (room == null) return ResponseViewModel<string>.Failure(ErrorCode.RoomNotFound, "Room not found");

            room.IsDeleted = true;
            _genericRepo.UpdateInclude(room, nameof(room.IsDeleted));
            return ResponseViewModel<string>.Success("Room deleted successfully");
        }
        public async Task<ResponseViewModel<List<RoomResponseDTO>>> GetAvailableRoomsAsync()
        {
            var availableRooms = await  _genericRepo.Get(r => r.Status == RoomStatus.Available)
                .Select(r => r.Map<RoomResponseDTO>()).ToListAsync();

            return ResponseViewModel<List<RoomResponseDTO>>.Success(availableRooms);
        }
    }

}
