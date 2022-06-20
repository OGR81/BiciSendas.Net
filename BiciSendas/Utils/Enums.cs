namespace BiciSendas.Utils
{
    public static class Enums
    {
        public enum Estados
        {
            Solucionado = 1,
            Pendiente = 2,
            NoTratado = 3
        }

        public enum TipoIncidencia
        {
            Bache = 1,
            Caida = 2,
            Obstaculo = 3,
            MalaSenalizacion = 4,
            Accidente = 5
        }

        public enum TipoSensor
        {
            Radar = 1,
            Contador = 2,
            Semaforo = 3,
            Interseccion = 4
        }
        public enum EstadoSen
        {
            Activado = 1,
            Desativado = 2
        }
        public enum TipoActuador
        {
            Iluminacion = 1,
            Señalizacion = 2,
            Advertencia = 3,
            Peligro = 4
        }

    }
}
