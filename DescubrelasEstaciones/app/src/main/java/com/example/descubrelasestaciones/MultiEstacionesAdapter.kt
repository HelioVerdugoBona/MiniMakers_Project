package com.example.descubrelasestaciones

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class MultiEstacionesAdapter(private val context: Context,
                             private val listaEstacion: MutableList<ItemEstaciones>):
    RecyclerView.Adapter<MultiEstacionesAdapter.MultiEstacionesViewHolder>()
{

    val layout = R.layout.item_image
    class MultiEstacionesViewHolder(val view: View) : RecyclerView.ViewHolder(view)
    {
        var imgEstacion: ImageView

        init {
            imgEstacion = view.findViewById(R.id.imageView)
        }

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MultiEstacionesViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)

        return MultiEstacionesViewHolder(view)

    }

    override fun getItemCount(): Int = listaEstacion.size


    override fun onBindViewHolder(holder: MultiEstacionesViewHolder, position: Int) {
        val itemEstacion = listaEstacion[position]
        bindEstacion(holder,itemEstacion)

    }

    fun bindEstacion(holder: MultiEstacionesViewHolder, itemEstacion: ItemEstaciones) {
        holder.imgEstacion.setImageResource(itemEstacion.imagen)
    }


}