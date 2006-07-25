//=-------
// Copyright 2005, Pedro Santana
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;
using System.Diagnostics;

using agsXMPP;


using System.Threading;

namespace mSalsa 
{
	/// <summary>
	/// Class to Manage the Jabber Client agsXMPP.
	/// </summary>
	public class JabberClient : XmppClientConnection
	{		
		
		/// <summary>
		/// Instance of Input class.
		/// </summary>
		private Input input;
		/// <summary>
		/// Instance of PassivePerception class.
		/// </summary>
		private PassivePerception p;

		/// <summary>
		/// Connect to the Jabber Server.
		/// </summary>
		/// <param name="server">Jabber Server.</param>
		/// <param name="port">Jabber Server Port.</param>
		/// <param name="user">Jabber User.</param>
		/// <param name="pass">Jabber User Password.</param>
		public JabberClient(string server, int port, string user, string pass)
		{
			this.OnReadXml += new XmlHandler(JabberClient_OnReadXml);
			this.OnWriteXml +=new XmlHandler(JabberClient_OnWriteXml);
			this.OnLogin += new ObjectHandler(JabberClient_OnLogin);
			this.OnError += new ErrorHandler(JabberClient_OnError);
			this.OnMessage += new MessageHandler(JabberClient_OnMessage);
			this.OnPresence += new PresenceHandler(JabberClient_OnPresence);

			this.Server = server;
			this.Username = user;
			this.Password = pass;
			this.Port = port;
			this.Resource = "mSalsa";

			this.Priority = 5;
			this.Status = "Online";

			try
			{
				this.Open(this.Username, this.Password, this.Resource);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}		
		}

		/// <summary>
		/// Set the reasoning component to the Jabber client.
		/// </summary>
		/// <param name="rsn">Reasoning component</param>
		public void setReasoning(Reasoning rsn)
		{
			p = new PassivePerception();
			p.setReasoning(rsn);
		}

		/// <summary>
		/// Event generated when receive the XML from the Jabber Server.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="xml">XML received.</param>
		private void JabberClient_OnReadXml(object sender, string xml)
		{
			/*Debug*/
			//Debug.WriteLine("RECV XML: " + xml);

			// TODO: Is you need do something
		}

		/// <summary>
		/// Event generated when sends the XML to the Jabber Server.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="xml">XML sent.</param>
		private void JabberClient_OnWriteXml(object sender, string xml)
		{
			/*Debug*/
			//Debug.WriteLine("SEND XML: " + xml);

			// TODO: Is you need do something
		}

		/// <summary>
		/// Event when Login into the Jabber Sever
		/// </summary>
		/// <param name="sender">Object sender.</param>
		private void JabberClient_OnLogin(object sender)
		{
			/*Debug*/
			//Debug.WriteLine("We are logged in to the server now");
			/*Debug*/
			//Debug.WriteLine("Set presence");
			this.SendMyPresence();
		}

		/// <summary>
		/// Event generated when Error.
		/// </summary>
		/// <param name="sender">Object Sender.</param>
		/// <param name="ex">Exception object.</param>
		private void JabberClient_OnError(object sender, Exception ex)
		{
			/*Debug*/
			//Debug.WriteLine("ERROR: " + ex.ToString());

			// TODO: Is you need do something
		}

		/// <summary>
		/// Event generated when receive a Jabber message.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="msg">The message.</param>
		private void JabberClient_OnMessage(object sender, agsXMPP.protocol.Message msg)
		{
			/*Debug*/
			//Debug.WriteLine("-->JabberClient: xmlMessage=" + msg.Xml);
			XMLmessage xmlMessage = new XMLmessage(msg.Xml);                  
            input = new Input(xmlMessage);			
			p.perceive(input);
		}

		/// <summary>
		/// Event generated when receive a Jabber presence message.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="pres">The presence message.</param>
		private void JabberClient_OnPresence(object sender, agsXMPP.protocol.Presence pres)
		{
			/*Debug*/
			//Debug.WriteLine("PRESENCE: " + pres.From);
			XMLpresence xmlPresence = new XMLpresence(pres.Xml);
			input = new Input(xmlPresence);
			p.perceive(input);
		}
	}
}
