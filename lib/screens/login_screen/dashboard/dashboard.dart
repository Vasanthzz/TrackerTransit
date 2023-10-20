import 'package:flutter/material.dart';

class dashboard extends StatelessWidget {
  const dashboard({Key? key}) : super(key : key);
  


  @override
  Widget build(BuildContext context){
    return Scaffold(
      appBar: (
        leading:const Icon(icons,menu,color: colors.black),
        title: Text(tAppName style: theme.of(context).textTheme.headline4)
        centerTitle: true
      ),
      body: SingleChildScrollView(
        child: Container(
          padding: const EdgeInsets.all(tDashboardPadding),
        )
        )
    )
  }
}