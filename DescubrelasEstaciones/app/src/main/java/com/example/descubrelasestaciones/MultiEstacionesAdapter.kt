package com.example.descubrelasestaciones

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class MultiEstacionesAdapter(private val context: Context,
                             private val listaEstacion: MutableList<ItemEstaciones>,
                             private val itemClickListener: (ItemEstaciones) -> Unit):
    RecyclerView.Adapter<MultiEstacionesAdapter.MultiEstacionesViewHolder>()
{

    private val layout = R.layout.item_image

    class MultiEstacionesViewHolder(val view: View, private val itemClickListener: (ItemEstaciones) -> Unit) : RecyclerView.ViewHolder(view)
    {
        var imgEstacion = view.findViewById<ImageView>(R.id.imageView)

        fun bind(item: ItemEstaciones) {
            itemView.setOnClickListener { itemClickListener(item) }
        }

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MultiEstacionesViewHolder 
    {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)
        return MultiEstacionesViewHolder(view, itemClickListener)
    }

    override fun getItemCount(): Int = listaEstacion.size


    override fun onBindViewHolder(holder: MultiEstacionesViewHolder, position: Int) {
        val itemEstacion = listaEstacion[position]
        bindEstacion(holder,itemEstacion)
        holder.bind(itemEstacion)
    }

    fun bindEstacion(holder: MultiEstacionesViewHolder, itemEstacion: ItemEstaciones) {
        holder.imgEstacion.setImageResource(itemEstacion.imagen)
    }


}