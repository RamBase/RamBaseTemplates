using System;
using System.Security.Cryptography;
using System.Text;

namespace $safeprojectname$.WebhookHandler
{
	/// <summary>
	/// Utility class for working with HMAC tokens
	/// </summary>
	public static class HMACUtil
	{
		/// <summary>
		/// Generate HMAC token from the given algorithm, secret and payload
		/// </summary>
		/// <param name="algorithm">Algorithm to use</param>
		/// <param name="token">Secret token</param>
		/// <param name="payload">Payload to generate token from</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static string GenerateHMACToken(HmacAlgorithm algorithm, string token, string payload)
		{
			if (string.IsNullOrWhiteSpace(token))
				throw new ArgumentException("Token is required", nameof(token));

			Encoding encoding = Encoding.UTF8;
			byte[] keyByte = encoding.GetBytes(token);
			byte[] data = encoding.GetBytes(payload);

			HMAC hmacEncoder = null;

			switch (algorithm)
			{
				case HmacAlgorithm.SHA256:
					hmacEncoder = new HMACSHA256(keyByte);
					break;
				case HmacAlgorithm.SHA512:
					hmacEncoder = new HMACSHA512(keyByte);
					break;
			}

			byte[] hashmessage = hmacEncoder.ComputeHash(data);
			return Convert.ToBase64String(hashmessage);
		}

		public enum HmacAlgorithm
		{
			SHA256,
			SHA512
		}
	}
}
