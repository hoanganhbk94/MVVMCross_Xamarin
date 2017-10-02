using System;
namespace HelloWorld
{
	public class UserModel : BaseModel
	{
		public UserModel(string email, string password)
		{
			this.email = email;
			this.password = password;
		}

		public string email { get; set; }

		public string password { get; set; }

		public override string ToString()
		{
			return string.Format("[UserModel: email={0}, password={1}]", email, password);
		}
	}
}
