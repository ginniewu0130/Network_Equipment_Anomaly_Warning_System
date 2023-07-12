﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PJ_Login.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        public IActionResult UploadFile()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                // 檢查副檔名
                if (extension == ".csv" || extension == ".txt")
                {
                    try
                    {
                        // 檔案儲存路徑
                        string relativePath = @"..\..\..\..\Mechine_Learning\log"; // 相對路徑
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                        // 確保路徑存在，如果不存在就建立資料夾
                        if (!Directory.Exists(fullPath))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        else
                        {
                            // 儲存現有檔案的處理
                            string existingFilePath = Path.Combine(fullPath, "train_log.txt");
                            if (System.IO.File.Exists(existingFilePath))
                            {
                                // 刪除現有檔案或進行其他處理
                                System.IO.File.Delete(existingFilePath);
                            }
                        }
                        // 檔案路徑
                        string filePath = Path.Combine(fullPath, "train_log.txt");


                        // 讀取 CSV 檔案內容
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {
                            string content = reader.ReadToEnd();

                            // 轉換為 TXT 格式 
                            string txtContent = ConvertToTxt(content);

                            // 儲存轉換後的 TXT 檔案
                            System.IO.File.WriteAllText(filePath, txtContent, Encoding.UTF8);

                            ViewBag.Message = "檔案已成功轉換並儲存。";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "轉換檔案時發生錯誤：" + ex.Message;
                    }
                }
                else
                {
                    ViewBag.Message = "請上傳 CSV 或 TXT 檔案。";
                }
            }

            return View();
        }
        private string ConvertToTxt(string csvContent)
        {
            
            return csvContent;
        }
        public IActionResult UploadFileAnomaly()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFileAnomaly(IFormFile file)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                // 檢查副檔名
                if (extension == ".csv" || extension == ".txt")
                {
                    try
                    {
                        // 檔案儲存路徑
                        string relativePath = @"..\..\..\..\Mechine_Learning\log"; // 相對路徑
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                        // 確保路徑存在，如果不存在就建立資料夾
                        if (!Directory.Exists(fullPath))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        else
                        {
                            // 儲存現有檔案的處理
                            string existingFilePath = Path.Combine(fullPath, "prediction_log.txt");
                            if (System.IO.File.Exists(existingFilePath))
                            {
                                // 刪除現有檔案或進行其他處理
                                System.IO.File.Delete(existingFilePath);
                            }
                        }

                        // 檔案路徑
                        string filePath = Path.Combine(fullPath, "prediction_log.txt");


                        // 讀取 CSV 檔案內容
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {
                            string content = reader.ReadToEnd();

                            // 轉換為 TXT 格式
                            string txtContent = ConvertToTxt(content);

                            // 儲存轉換後的 TXT 檔案
                            System.IO.File.WriteAllText(filePath, txtContent, Encoding.UTF8);

                            ViewBag.Message = "檔案已成功轉換並儲存。";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "轉換檔案時發生錯誤：" + ex.Message;
                    }
                }
                else
                {
                    ViewBag.Message = "請上傳 CSV 或 TXT 檔案。";
                }
            }

            return View();
        }
    }
}
