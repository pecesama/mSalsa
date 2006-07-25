//=-------
// Copyright 2005, Irma Amaya
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;

namespace mSalsa
{
	/// <summary>
	/// Simple XML Parser.
	/// </summary>
	public class Parser
	{
		/// <summary>
		/// The XML document.
		/// </summary>
		private string xml;		

		/// <summary>
		/// Create an instance of the parser.
		/// </summary>
		/// <param name="xml">The XML document.</param>
		public Parser(string xml)
		{
			this.xml = xml;
		}

		/// <summary>
		/// Get the value of some tag.
		/// </summary>
		/// <param name="element">The XML tag.</param>
		/// <returns>The value of the tag.</returns>
		public string getTag(string element)
		{
			int c, c2, d;
			string valor = null;
			string ini = '<' + element + '>'; 
			c = xml.IndexOf(ini);			
			
			// si encontro la ocurrencia del elemento dentro del mensaje xml
			if(c > 0)
			{
				// busca el fin del elemento
				string fin = "</" + element + '>';
				
				c2 = xml.IndexOf(fin, ini.Length);
				// calcula la diferencia entre el inicio y fin del elemento
				d = (c2) - (c + ini.Length);
				// asigna el valor del elemento
				valor = xml.Substring(c+ini.Length, d);
			}
			return valor;
		}		

		/// <summary>
		/// Get the attribute of a XML node.
		/// </summary>
		/// <param name="node">The XML node</param>
		/// <param name="att">The attribute to search</param>
		/// <returns>The value of the attribute.</returns>
		public string getAtt(string node, string att)
		{
			int c, c3, c4, d;
			string valor = null;
			string elem = "<" + node;
			c = xml.IndexOf(elem, 0); 

			if(c >= 0)
			{
				// busca el atributo dentro del nodo
				string ini = att + "="; 	
				// busca el fin del elemento
				c3 = xml.IndexOf(ini, c);
				c4 = xml.IndexOf('"', (c3 + ini.Length+1));
				d = c4 - (c3 + ini.Length);
				valor = xml.Substring((c3 + ini.Length+1), (d-1));
			}
			return valor;
		}		
		
		/// <summary>
		/// Get the type of XML Message.
		/// </summary>
		/// <returns>The type of message in a string.</returns>
		public string getType()
		{
			int c, c3, c4, d;
			string valor = null;
			string elem = "<x";
			c = xml.IndexOf(elem, 0); 

			if(c > 0)
			{
				// busca la etiqueta dentro del elemento
				string ini = "xmlns="; 	
				// busca el fin del elemento
				c3 = xml.IndexOf(ini, c);
				c4 = xml.IndexOf(">", c3 + ini.Length);
				d = c4 - (c3 + ini.Length);
				valor = xml.Substring(c3 + ini.Length, d);
				// determina el tipo de evento
				// y regresa el tipo de evento
				c4 = valor.IndexOf("x:", 0);
				valor = valor.Substring((c4 + 2), (valor.Length - 4));
			}
			else 
				valor = "simpleMessage";
			return valor;
		}

		#region Obsolete methods

		/// <summary>
		/// Create an instance of the parser.
		/// </summary>
		[Obsolete("Use Parser(string xml) instead", true)]
		public Parser() {}				
		
		/// <summary>
		/// Get the type of XML Message.
		/// </summary>		
		/// <param name="element">The XML tag.</param>
		/// <param name="tag">The XML attribute to search the type.</param>
		/// <returns>The type of message in a string.</returns>
		[Obsolete("Use getType() instead", true)]
		public string getType(string element, string tag) { return "";	}

		#endregion
	}
}
