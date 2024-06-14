using System.Text;
using System.Text.RegularExpressions;

namespace Dummy.Core.Utilities;

public static class StringUtil
{
    /// <summary>
    /// Verifica se o CPF está estruturado de uma forma válida.
    /// </summary>
    /// <param name="cpf">String com os numeros do cpf</param>
    /// <returns>False caso CPF seja inválido</returns>
    public static bool ValidateIndividualTaxpayerDocument(this string document)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        document = document.Trim();
        document = document.Replace(".", "").Replace("-", "");
        if (document.Length != 11)
            return false;
        tempCpf = document.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf += digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return document.EndsWith(digito);
    }

    /// <summary>
    /// Verifica se o CNPJ está estruturado de uma forma válida.
    /// </summary>
    /// <param name="cnpj">String com os numeros do CNPJ</param>
    /// <returns>False caso CNPJ seja inválido</returns>
    public static bool ValidateCorporateTaxpayerDocument(this string document)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;
        document = document.Trim();
        document = document.Replace(".", "").Replace("-", "").Replace("/", "");
        if (document.Length != 14)
            return false;
        tempCnpj = document.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return document.EndsWith(digito);
    }

    /// <summary>
    /// Verifica se o endereço de e-mail é válido.
    /// </summary>
    /// <param name="email">Endereço de e-mail</param>
    /// <returns>False caso e-mail seja inválido</returns>
    public static bool ValidateEmail(this string email)
    {
        Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

        if (rg.IsMatch(email))
            return true;

        return false;
    }

    /// <summary>
    /// Válida se o número de telfone atende aos padrões recentes(2020)
    /// </summary>
    /// <param name="telefone">String com numero do telefone</param>
    /// <returns>False caso número seja inválido</returns>
    public static bool ValidatePhoneNumber(this string phoneNumber)
    {
        phoneNumber = phoneNumber.ExtractNumbers();

        if (phoneNumber.Length < 10)
            return false;

        phoneNumber = phoneNumber.ToInt64().ToString();

        if (phoneNumber.Length < 10)
            return false;

        return true;
    }

    /// <summary>
    /// Extrai caracteres numéricos da string.
    /// </summary>
    /// <param name="texto">string para remoção dos caracteres</param>
    /// <returns>String com os numéricos apenas</returns>
    public static string ExtractNumbers(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "";

        StringBuilder s = new StringBuilder();
        foreach (var c in text)
        {
            if (char.IsDigit(c))
                s.Append(c);
        }
        return s.ToString();
    }

    public static string MaskName(this string texto, int caracteresManter = 1)
    {
        if (texto == null)
            return null;

        if (string.IsNullOrWhiteSpace(texto))
            return null;

        if (caracteresManter < 1)
            caracteresManter = 1;

        StringBuilder sbRetorno = new StringBuilder();
        string[] nomes = texto.TrimEnd().Split(' ');
        foreach (var nome in nomes)
        {
            if (caracteresManter < nome.Length)
                sbRetorno.Append(nome.Substring(0, caracteresManter).PadRight(nome.Length, '*'));
            else
                sbRetorno.Append(nome);
            sbRetorno.Append(" ");
        }
        return sbRetorno.ToString().Trim();
    }

    /// <summary>
    /// Mascara endereço de e-mail.
    /// </summary>
    /// <param name="texto">endereço de e-mail</param>
    /// <param name="caracteresManter">caracteres a serem mantidos</param>
    /// <returns>E-mail com mascara</returns>
    public static string MaskEmail(this string texto, int caracteresManter = 1)
    {
        if (texto == null)
            return null;

        if (string.IsNullOrWhiteSpace(texto))
            return null;

        var partes = texto.Split('@');
        if (partes.Length == 2)
        {
            texto = partes[0].MaskName(caracteresManter) + "@" + partes[1];
        }
        else
        {
            texto = texto.MaskName(caracteresManter);
        }
        return texto;
    }

    /// <summary>
    /// Adiciona marcacoes na string do documento.
    /// </summary>
    /// <param name="documento">CPF(11 caracters) ou CNPJ(14 caracteres)</param>
    /// <param name="formatacaoInicial">Extrai os numeros da string</param>
    /// <returns>Documento formatado com pontuação</returns>
    public static string FormatDocument(this string documento, bool formatacaoInicial = true)
    {
        if (formatacaoInicial)
            documento = ExtractNumbers(documento);

        if (documento.Length == 11)
        {
            documento = documento.Insert(9, "-");
            documento = documento.Insert(6, ".");
            documento = documento.Insert(3, ".");
        }
        else if (documento.Length == 14)
        {
            documento = documento.Insert(12, "-");
            documento = documento.Insert(8, "/");
            documento = documento.Insert(5, ".");
            documento = documento.Insert(2, ".");
        }
        else
        {
            return "";
        }

        return documento;
    }

    /// <summary>
    /// Adiciona marcações na string do Telefone.
    /// </summary>
    /// <param name="telefone">Numero de Telefone com DDD</param>
    /// <returns>Telefone formatado</returns>
    public static string FormatPhoneNumber(this string telefone)
    {
        string strMascara = "{0:(00)0000-0000}";

        telefone = telefone.ExtractNumbers();
        if (telefone.Length == 11)
            strMascara = "{0:(00)00000-0000}";

        return string.Format(strMascara, Convert.ToInt32(telefone));
    }
}