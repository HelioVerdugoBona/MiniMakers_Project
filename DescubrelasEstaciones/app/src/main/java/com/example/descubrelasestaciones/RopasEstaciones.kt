package com.example.descubrelasestaciones

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.util.Log
import android.view.DragEvent
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.ContextCompat
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView
import com.example.descubrelasestaciones.ColoresEstaciones.ColoresConstats

class RopasEstaciones: AppCompatActivity ()
{
    object RopasConstats {
        const val INFONEN = "INFONEN"
    }

    private var startTime = System.currentTimeMillis()
    private var intentos = 0
    private var infoNen = InfoNen("Error","Error","Error","Error","Error",
        "Error","Error","Error","Error","Error")

    private lateinit var mediaPlayer: MediaPlayer

    private lateinit var anmCorrect1: LottieAnimationView
    private lateinit var anmCorrect2: LottieAnimationView
    private lateinit var anmCorrect3: LottieAnimationView
    private lateinit var anmCorrect4: LottieAnimationView

    private val arrayAnimations by lazy {
        mutableListOf (anmCorrect1,
            anmCorrect2,
            anmCorrect3,
            anmCorrect4)

    }

    private val itemsEstaciones = mutableListOf(
        ItemEstaciones("1", "Bañador", R.drawable.banyador),
        ItemEstaciones("2", "CamiaFlor", R.drawable.camisetaflor),
        ItemEstaciones("3", "Chubasquero", R.drawable.chubasquero),
        ItemEstaciones("4", "Bufanda", R.drawable.bufanda)
    )

    private val arrayEstaciones = mutableListOf(
        ItemEstaciones("1", "Verano", R.drawable.estiu),
        ItemEstaciones("2", "Primavera", R.drawable.primavera),
        ItemEstaciones("3", "Otoño", R.drawable.tardor),
        ItemEstaciones("4", "Invierno", R.drawable.hivern)
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.ropas_estaciones)
        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        mediaPlayer = MediaPlayer.create(this, R.raw.musicafondo)

        anmCorrect1 = findViewById(R.id.ANMCorrect1)
        anmCorrect2 = findViewById(R.id.ANMCorrect2)
        anmCorrect3 = findViewById(R.id.ANMCorrect3)
        anmCorrect4 = findViewById(R.id.ANMCorrect4)

        if (mediaPlayer != null) {
            // Configurar la música para que se repita
            mediaPlayer.isLooping = true

            // Iniciar la reproducción
            mediaPlayer.start()
        } else {
            Log.e("MediaPlayerError", "MediaPlayer no se pudo inicializar.")
        }
        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewRopas)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewRopas2)

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
        recyclerView1.layoutManager = GridLayoutManager(this,4)
        recyclerView1.adapter = adapterItem


        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion
        recyclerView1.setOnDragListener { view, event ->
            when (event.action) {
                DragEvent.ACTION_DRAG_STARTED  -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 0f
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

                        // Compara los atributos
                        if (draggedAttribute == targetItem.id) {
                            val iterator = itemsEstaciones.iterator()
                            while (iterator.hasNext()) {
                                val item = iterator.next()
                                if (draggedAttribute == item.id) {
                                    iterator.remove() // Elimina usando el iterador
                                    adapterItem.notifyDataSetChanged()
                                    viewUnder?.setBackgroundColor(ContextCompat.getColor(this, R.color.green))
                                    runAnimatic(item.id.toInt()-1)
                                    break // Salir del bucle después de eliminar
                                }
                            }
                            if(itemsEstaciones.size == 0){
                                nextLevel()
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
        val intent = Intent(this, PantallaFinal::class.java)
        val endTime = System.currentTimeMillis()
        val elapsedTime = endTime - startTime // en milisegundos
        Log.d("Timer", "Tiempo transcurrido: ${elapsedTime}ms")
        infoNen.tempsNVL3 = (elapsedTime/1000).toString()
        infoNen.erradesNVL3 = intentos.toString()
        intent.putExtra(PantallaFinal.InfoNens.INFONEN,infoNen)
        startActivity(intent)
    }

    private fun runAnimatic(index: Int){
        arrayAnimations[index].visibility = View.VISIBLE
        arrayAnimations[index].playAnimation()
    }

    override fun onResume() {
        super.onResume()
        // Reiniciar la música si se detuvo al pausar la aplicación
        if (!mediaPlayer.isPlaying) {
            mediaPlayer.start()
        }
    }

    override fun onPause() {
        super.onPause()
        // Pausar la música cuando la actividad no esté visible
        mediaPlayer.pause()
    }

    override fun onDestroy() {
        super.onDestroy()
        // Liberar el MediaPlayer para evitar fugas de memoria
        mediaPlayer.release()
    }
}