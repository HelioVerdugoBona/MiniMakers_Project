package com.example.simondicefinal.activities

import android.graphics.Color
import android.os.Bundle
import android.os.Handler
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.simondicefinal.FilesManager
import com.example.simondicefinal.datamodel.Partida
import com.example.simondicefinal.R
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import kotlin.random.Random

class SimonActivity : AppCompatActivity() {

    // Declaración de variables globales
    private var tiempoInicial: Long = 0

    private var secuencia = mutableListOf<Int>()
    private var secuenciaJugador = mutableListOf<Int>()

    private var handler = Handler()

    private var nombre: String = ""

    private var partidas = mutableListOf<Partida>()


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_simon)

        // Recibir objeto intent de la activity anterior y guardar el String enviado en una variable
        val intent = getIntent()
        nombre = intent.getStringExtra("NOMBRE").toString()

        // Asignar los elementos del layout a su varible correspondiente
        val btnVerde = findViewById(R.id.BtnVerde) as Button
        val btnRojo = findViewById(R.id.BtnRojo) as Button
        val btnAzul = findViewById(R.id.BtnAzul) as Button
        val btnAmarillo = findViewById(R.id.BtnAmarillo) as Button

        val btnReinicio = findViewById(R.id.BtnRestart) as Button
        val txtEstado = findViewById(R.id.TxtStatus) as TextView

        // Desactivar los botones de colores
        activarBotones(false, btnVerde, btnRojo, btnAzul, btnAmarillo)

        // Asignar listeners a los botones de colores
        btnVerde.setOnClickListener { pulsarBoton(0, txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo) }
        btnRojo.setOnClickListener { pulsarBoton(1, txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo) }
        btnAzul.setOnClickListener { pulsarBoton(2, txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo) }
        btnAmarillo.setOnClickListener { pulsarBoton(3, txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo) }

        // Comprueva si el archivo.json existe, si no existe lo crea y añade una partida de ejemplo
        if (!FilesManager.comprovarArchivo(this)) {
            partidaEjemplo()
        }

        // Iniciar el juego
        iniciarJuego(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)

        // Al pulsar el botón reiniciar la partida
        btnReinicio.setOnClickListener {
            iniciarJuego(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)
        }
    }

    // Iniciar el juego
    private fun iniciarJuego(txtEstado: TextView, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        tiempoInicial = System.currentTimeMillis()
        activarBotones(false, btnVerde, btnRojo, btnAzul, btnAmarillo)
        secuencia.clear()
        secuenciaJugador.clear()
        txtEstado.text = "Observa la secuencia"
        handler.postDelayed({
            anadirSecuencia(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)
        }, 1500)
    }

    private fun anadirSecuencia(txtEstado: TextView, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        // Añadir un color aleatorio a la secuencia
        val colorRandom = Random.nextInt(4)
        secuencia.add(colorRandom)

        // Mostrar la secuencia al jugador
        mostrarSecuencia(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)
    }

    private fun mostrarSecuencia(txtEstado: TextView, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        activarBotones(false, btnVerde, btnRojo, btnAzul, btnAmarillo)
        txtEstado.text = "Mostrando secuencia..."

        // Mostrar la secuencia en intervalos de 1 segundo
        for ((index, color) in secuencia.withIndex()) {
            handler.postDelayed({
                iluminarBotones(color, btnVerde, btnRojo, btnAzul, btnAmarillo)
            }, (index * 1000).toLong())
        }

        // Al terminar de mostrar la secuencia esperar 1 segundo para activar los botones
        handler.postDelayed({
            activarBotones(true, btnVerde, btnRojo, btnAzul, btnAmarillo)
            txtEstado.text = "Tu turno"
        }, (secuencia.size * 1000).toLong())
    }

    // Detectar que boton se ha pulsado e iluminarlo
    private fun iluminarBotones(color: Int, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        when (color) {
            0 -> iluminarBoton(btnVerde, Color.GREEN)
            1 -> iluminarBoton(btnRojo, Color.RED)
            2 -> iluminarBoton(btnAzul, Color.BLUE)
            3 -> iluminarBoton(btnAmarillo, Color.YELLOW)
        }
    }

    // Cambiar el color del boton y volver a poner el original 0,5 segundos después
    private fun iluminarBoton(button: Button, color: Int) {
        val colorOriginal = button.solidColor
        button.setBackgroundColor(color)
        handler.postDelayed({
            button.setBackgroundColor(colorOriginal)
        }, 500)
    }

    // Guardar el codigo de color del boton pulsado y comparar el tamaño de las secuencias
    private fun pulsarBoton(color: Int, txtEstado: TextView, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        secuenciaJugador.add(color)
        if (secuenciaJugador.size == secuencia.size) {
            activarBotones(false, btnVerde, btnRojo, btnAzul, btnAmarillo)
            comprovarSecuencia(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)
        }
    }

    // Comparar las dos secuencias, en caso de que no sean iguales guardar los datos de la partida y preparar la siguiente
    private fun comprovarSecuencia(txtEstado: TextView, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        if (secuenciaJugador == secuencia) {
            txtEstado.text = "¡Correcto! Añadiendo mas..."
            secuenciaJugador.clear()
            handler.postDelayed({
                anadirSecuencia(txtEstado, btnVerde, btnRojo, btnAzul, btnAmarillo)
            }, 1000)
        } else {
            // Guardar el tiempo que ha durado la partida
            val tiempoFinal = System.currentTimeMillis()
            val tiempoTranscurrido = ((tiempoFinal - tiempoInicial) / 1000).toInt()

            activarBotones(false, btnVerde, btnRojo, btnAzul, btnAmarillo)
            guardarPartida(tiempoTranscurrido)
            handler.postDelayed({
                finish()
            }, 1000)
        }
    }

    // Activar o desactivar los botones de colores
    private fun activarBotones(activado: Boolean, btnVerde: Button, btnRojo: Button, btnAzul: Button, btnAmarillo: Button) {
        btnVerde.isEnabled = activado
        btnRojo.isEnabled = activado
        btnAzul.isEnabled = activado
        btnAmarillo.isEnabled = activado
    }

    // Obtener el registro de partidas guardadas y guardar la nueva partida en el archivo .json
    private fun guardarPartida(tiempoTranscurrido: Int) {
        partidas = FilesManager.obtenerPartidas(this)

        val fechaActual = LocalDateTime.now()
        val formateador = DateTimeFormatter.ofPattern("dd-MM-yyyy")
        val fechaFormatada = fechaActual.format(formateador)

        val partida = Partida(nombre, secuencia.size, tiempoTranscurrido, fechaFormatada)
        partidas.add(partida)
        FilesManager.guardarPartidas(this, partidas)
    }

    // Crea una prtida de ejemplo y la guarda en el archivo .json
    private fun partidaEjemplo() {
        val ejemplo = Partida("ejemplo", 0, 0, "00-00-0000")
        partidas.add(ejemplo)
        FilesManager.guardarPartidas(this, partidas)
    }
}
