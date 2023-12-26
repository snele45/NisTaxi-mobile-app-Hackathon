import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, ScrollView, Image, Button, Pressable } from 'react-native';

export default function ReceiptsScreen() {
  return (
    <View style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false} showsHorizontalScrollIndicator={false} style={styles.scrollView}>
      <View style={styles.receiptView}>

        <View style={styles.receiptBox}>
          <Text style={styles.dateText}>20.11.2023, 15:12</Text>
          <Text style={styles.gasStationText}>B.S. Novi Sad 1</Text>
          <Text style={styles.fuelTypeText}>OPTI BMB 95</Text>

          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/fuelStation.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>50l</Text>
          </View>
          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/money.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>9000 RSD</Text>
          </View>
        </View>

        <View style={styles.receiptBox}>
          <Text style={styles.dateText}>19.11.2023, 12:12</Text>
          <Text style={styles.gasStationText}>B.S. Novi Beograd 1</Text>
          <Text style={styles.fuelTypeText}>OPTI BMB 95</Text>

          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/fuelStation.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>50l</Text>
          </View>
          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/money.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>7300 RSD</Text>
          </View>
        </View>

        <View style={styles.receiptBox}>
          <Text style={styles.dateText}>10.11.2023, 18:12</Text>
          <Text style={styles.gasStationText}>B.S. Novi Sad 1</Text>
          <Text style={styles.fuelTypeText}>OPTI BMB 95</Text>

          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/fuelStation.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>55l</Text>
          </View>
          <View style={{flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10}}>
            <Image source={require('./../assets/money.png')} style={styles.icon}/>
            <Text style={styles.fuelPrice}>8300 RSD</Text>
          </View>
        </View>
        
      </View>
      <StatusBar style="auto" />
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    width: '100%',
    backgroundColor: '#fff',
    paddingLeft: 20,
    paddingRight: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  scrollView:{
    width: '100%',
  },
  receiptView:{
    marginTop: 20,
  },
  receiptBox:{
    paddingTop: 20,
    paddingLeft: 20,
    paddingRight: 20,
    paddingBottom: 20,
    marginTop: 20,
    width: '100%',
    height: 180,
    backgroundColor: '#F5BF24',
    borderRadius: 10,
  },
  dateText:{
    fontSize: 16,
    fontWeight: '400',
    color: '#fff',
  },
  gasStationText:{
    fontSize: 24,
    fontWeight: '700',
    color: '#fff',
  },
  fuelTypeText:{
    fontSize: 16,
    fontWeight: '300',
    color: '#fff',
  },
  icon:{
    width: 15,
    height: 15,
  },
  fuelPrice:{
    fontSize: 17,
    fontWeight: '400',
    color: '#fff',
    marginLeft: 7,
  },
});
