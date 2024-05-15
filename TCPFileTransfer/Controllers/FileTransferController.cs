using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace TCPFileTransfer.Controllers
{
    public class FileTransferController : Controller
    {
        // GET: FileTransfer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }

                using (var client = new TcpClient("172.16.16.47", 8088)) // Provide your server IP address and port number
                using (var stream = client.GetStream())
                {
                    // Send file name and data to the server
                    using (var writer = new BinaryWriter(stream))
                    {
                        writer.Write(file.FileName);
                        writer.Write(fileData.Length);
                        writer.Write(fileData);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}