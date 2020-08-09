using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelAppWeb.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _data;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        public List<RoomTypeModel> AvailableRoomTypes { get; set; }
        
        [BindProperty(SupportsGet = true)] 
        public bool SearchEnabled { get; set; } = false;

        public RoomSearchModel(IDatabaseData data)
        {
            _data = data;
        }
        public void OnGet()
        {
            if (SearchEnabled == true)
            {
               AvailableRoomTypes = _data.GetAvailableRoomTypes(StartDate, EndDate);
                
            }   
        }

        public IActionResult OnPost()
        {
            
            return RedirectToPage(new
            {
                SearchEnabled = true, 
                StartDate = StartDate.ToString("yyyy-MM-dd"), 
                EndDate = EndDate.ToString("yyyy-MM-dd")
            });
        }
    }
}