namespace ControWell.Client.Services.UsuarioService
{
    public interface IUsuarioService
    {
        List<Usuario> Usuarios { get; set; }
        Task GetUsuarios();
        Task<Usuario> GetSigleUsuario(int id);
    }
}
