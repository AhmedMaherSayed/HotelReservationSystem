﻿using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Services;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

      
        [HttpGet]
        public async Task<ResponseViewModel<List<RoomViewModel>>> GetAll()
        {
            return await _roomService.GetAll();
        }

     
        [HttpGet("{id}")]
        public async Task<ResponseViewModel<RoomViewModel>> GetById(int id)
        {
            return await _roomService.GetByIdAsync(id);
        }

        
        [HttpPost]
        public async Task<ResponseViewModel<RoomViewModel>> Create([FromForm] CreateRoomDTO roomDto)
        {
            if (roomDto == null) return ResponseViewModel<RoomViewModel>.Failure(ErrorCode.InvalidRoomRequest, "Invalid room data.");

            return await _roomService.Create(roomDto);
        }

        
        [HttpPut("{id}")]
        public async Task<ResponseViewModel<RoomViewModel>> Update(int id, [FromBody] UpdateRoomDTO roomDto)
        {
            if (roomDto == null) return ResponseViewModel<RoomViewModel>.Failure(ErrorCode.InvalidRoomRequest, "Invalid room data.");

            return await _roomService.UpdateAsync(id, roomDto);
        }

       
        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<string>> Delete(int id)
        {
            return await _roomService.DeleteAsync(id);
        }

        
        [HttpGet("available")]
        public async Task<ResponseViewModel<List<RoomViewModel>>> GetAvailableRooms()
        {
            return await _roomService.GetAvailableRoomsAsync();
        }
    }
}
