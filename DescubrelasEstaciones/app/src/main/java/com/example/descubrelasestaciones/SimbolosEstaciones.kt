package com.example.descubrelasestaciones

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import android.view.DragEvent
import android.view.View
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView
import com.example.descubrelasestaciones.ColoresEstaciones.ColoresConstats
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class SimbolosEstaciones: AppCompatActivity ()
{

    object SimbolosConstats {
        const val INFONEN = "INFONEN"
    }

    private var startTime = System.currentTimeMillis()
    private var intentos = 0
    private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error")

    private lateinit var musica: MediaPlayer
    private lateinit var correctSFX: MediaPlayer
    private lateinit var confetti: MediaPlayer
    private lateinit var yay: MediaPlayer
    private lateinit var aconseguit: MediaPlayer

    private lateinit var anmCorrect1: LottieAnimationView
    private lateinit var anmCorrect2: LottieAnimationView
    private lateinit var anmCorrect3: LottieAnimationView
    private lateinit var anmCorrect4: LottieAnimationView

    private val arrayAnimationsCorrect by lazy {
        mutableListOf (anmCorrect1,
            anmCorrect2,
            anmCorrect3,
            anmCorrect4)

    }

    private lateinit var anmConfetti: LottieAnimationView

    private val itemsEstaciones = mutableListOf<ItemEstaciones>()
    private val arrayEstaciones = mutableListOf<ItemEstaciones>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.simbolos_estaciones)

        anmCorrect1 = findViewById(R.id.ANMCorrect1)
        anmCorrect2 = findViewById(R.id.ANMCorrect2)
        anmCorrect3 = findViewById(R.id.ANMCorrect3)
        anmCorrect4 = findViewById(R.id.ANMCorrect4)
        anmConfetti = findViewById(R.id.ANMConfetti)

        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        musica = MediaPlayer.create(this, R.raw.musicafondo)
        correctSFX = MediaPlayer.create(this, R.raw.correctsfx)
        confetti = MediaPlayer.create(this, R.raw.confetti)
        yay = MediaPlayer.create(this, R.raw.yay)

        itemsEstaciones.addAll(mutableListOf( ItemEstaciones("1", "Sol", R.drawable.sol,MediaPlayer.create(this, R.raw.sol)),
            ItemEstaciones("2", "Flor", R.drawable.flor,MediaPlayer.create(this, R.raw.flor)),
            ItemEstaciones("3", "Fulla", R.drawable.hoja,MediaPlayer.create(this, R.raw.fulla)),
            ItemEstaciones("4", "FlocDeNeu", R.drawable.coponieve,MediaPlayer.create(this, R.raw.flocdeneu))))

        arrayEstaciones.addAll(mutableListOf(ItemEstaciones("1", "Verano", R.drawable.estiu,MediaPlayer.create(this, R.raw.estiu)),
            ItemEstaciones("2", "Primavera", R.drawable.primavera,MediaPlayer.create(this, R.raw.primavera)),
            ItemEstaciones("3", "Otoño", R.drawable.tardor,MediaPlayer.create(this, R.raw.tardor)),
            ItemEstaciones("4", "Invierno", R.drawable.hivern,MediaPlayer.create(this, R.raw.hivern))))

        if (musica != null) {
            // Configurar la música para que se repita
            musica.isLooping = true

            // Iniciar la reproducción
            musica.start()
        } else {
            Log.e("MediaPlayerError", "MediaPlayer no se pudo inicializar.")
        }

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewSimbolos)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewSimbolos2)

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)
    }

    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {

        itemsEstaciones.shuffle()

        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones, true)
        recyclerView1.layoutManager = LinearLayoutManager(this)
        recyclerView1.layoutManager = GridLayoutManager(this,4)
        recyclerView1.adapter = adapterItem


        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = LinearLayoutManager(this)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion

        recyclerView1.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DRAG_STARTED  -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 0f

                    val targetPosition =
                        if (draggedView != null) {
                            recyclerView1.getChildAdapterPosition(draggedView)
                        } else {
                            RecyclerView.NO_POSITION
                        }
                    val item = itemsEstaciones[targetPosition]
                    item.sound.start()
                    true

                }else -> true

            }
        }

        recyclerView2.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    // val draggedItem = event.localState as ItemEstaciones
                    // Obtener el atributo del ítem arrastrado
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f
                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                    println("El ID del draggedAttribute es: $draggedAttribute")

                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition = if (viewUnder != null) {
                        recyclerView2.getChildAdapterPosition(viewUnder)
                    } else {
                        RecyclerView.NO_POSITION
                    }
                    println("El targetPosition es: $targetPosition")


                    if (targetPosition != RecyclerView.NO_POSITION) {
                        val targetItem = arrayEstaciones[targetPosition]
                        targetItem.sound.start()
                        // Compara los atributos
                        if (draggedAttribute == targetItem.id) {
                            val iterator = itemsEstaciones.iterator()
                            while (iterator.hasNext()) {
                                val item = iterator.next()
                                if (draggedAttribute == item.id) {
                                    iterator.remove() // Elimina usando el iterador
                                    adapterItem.notifyDataSetChanged()
                                    // viewUnder?.setBackgroundColor(ContextCompat.getColor(this, R.color.green))
                                    runAnimatic(targetItem.id.toInt()-1,arrayAnimationsCorrect)
                                    correctSFX.start()
                                    Handler(Looper.getMainLooper()).postDelayed({
                                        if (viewUnder != null) {
                                            viewUnder.visibility = View.INVISIBLE
                                        }
                                    }, 500)
                                    adapterEstacion.notifyDataSetChanged()
                                    break // Salir del bucle después de eliminar
                                }
                            }
                            if(itemsEstaciones.size == 0){
                                val txtFelicitar: TextView = findViewById(R.id.txtFelicitar)
                                txtFelicitar.visibility = View.VISIBLE
                                anmConfetti.playAnimation()
                                confetti.start()
                                Handler(Looper.getMainLooper()).postDelayed({
                                    aconseguit.start()
                                    anmConfetti.playAnimation()
                                    confetti.start()
                                }, 2000)
                                Handler(Looper.getMainLooper()).postDelayed({
                                    nextLevel()
                                }, 2500)
                            }
                            Log.d("DragAndDrop", "Atributos coinciden")

                        } else {
                            Log.d("DragAndDrop", "Atributos no coinciden")
                            intentos++
                        }
                    }
                    true
                }
                DragEvent.ACTION_DRAG_ENDED -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f
                    true
                }

                else -> true
            }
        }
    }

    private fun nextLevel() {
        val intent = Intent(this, RopasEstaciones::class.java)
        val endTime = System.currentTimeMillis()
        val elapsedTime = endTime - startTime // en milisegundos
        Log.d("Timer", "Tiempo transcurrido: ${elapsedTime}ms")
        infoNen.tempsNVL2 = (elapsedTime/1000).toInt()
        infoNen.erradesNVL2 = intentos.toString()
        intent.putExtra(RopasEstaciones.RopasConstats.INFONEN,infoNen)
        lifecycleScope.launch {
            delay(500)
            startActivity(intent)
        }

    }

    private fun runAnimatic(index: Int, arrayAnimations: MutableList<LottieAnimationView>){
        arrayAnimations[index].visibility = View.VISIBLE
        arrayAnimations[index].playAnimation()
        lifecycleScope.launch {
            delay(1500)
            arrayAnimations[index].visibility = View.GONE
        }
    }

    override fun onResume() {
        super.onResume()
        // Reiniciar la música si se detuvo al pausar la aplicación
        if (!musica.isPlaying) {
            musica.start()
        }
    }

    override fun onPause() {
        super.onPause()
        // Pausar la música cuando la actividad no esté visible
        musica.pause()
    }

    override fun onDestroy() {
        super.onDestroy()
        // Liberar el MediaPlayer para evitar fugas de memoria
        musica.release()
    }
}