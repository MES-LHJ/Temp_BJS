using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Server.Model
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }  // MongoDB의 ObjectId를 문자열로 표현

        [BsonElement("UserId")]
        public string UserId { get; set; }    // 사용자 아이디

        [BsonElement("UserName")]
        public string UserName { get; set; }    // 사용자 이름

        [BsonElement("Password")]
        public string Password { get; set; }    //bycrypt 암호화된 비밀번호

        public DateTime LoginTime { get; set; } = DateTime.UtcNow;    //로그인 시간

        [BsonElement("NickName")]
        public string NickName { get; set; }    //표시 이름
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
