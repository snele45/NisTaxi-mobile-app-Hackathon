import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, ScrollView, Image, Button, Pressable, Dimensions } from 'react-native';
import QRCode from 'react-native-qrcode-svg';
import QRCodeStyled from 'react-native-qrcode-styled';
import { useEffect } from 'react';
import { getUserById } from '../services/userService';
import jwt_decode from "jwt-decode";
import { AuthContext } from '../context/AuthContext';
import { useContext } from 'react';
import { useState } from 'react';
import { Linking } from 'react-native';


const userIcon = require('./../assets/userIcon.png');
const logoImg = require('./../assets/logo.png');
const receiptIcon = require('./../assets/receipt.png');


export default function HomeScreen({ navigation }) {
  const [user, setUser] = useState([]);
  const { userId } = useContext(AuthContext);

  loadInBrowser = () => {
    Linking.openURL("https://www.nisgazprom.rs/sr/programi-lojalnosti/nis-taxi-kartica/").catch(err => console.error("Couldn't load page", err));
  };

  useEffect(() => {
    getUserById(userId, setUser);
  }, []);


  return (
    <View style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false} showsHorizontalScrollIndicator={false} style={styles.scrollView}>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'flex-end'}}>
        <Pressable onPress={() => navigation.navigate("Receipts")}>
          <Image source={receiptIcon} style={styles.receiptIcon}/>
        </Pressable>
      </View>
      <Pressable onPress={() => navigation.navigate("Account")}>
        <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
            <Image source={userIcon} style={styles.userIcon}></Image>
            <Text style={styles.nameText}>{user.driverName}</Text>
            <Text style={styles.fuelText}>{user.fuelNameFirst}</Text>
            <Text style={styles.fuelText}>{user.fuelNameSecond}</Text>

        </View>
      </Pressable>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <QRCodeStyled
          data={user.taxiCardNumber}
          style={styles.svg}
          padding={20}
          pieceSize={12}
          color={'#000'}
          errorCorrectionLevel={'H'}
          innerEyesOptions={{
            borderRadius: 12,
            color: '#000',
          }}
          outerEyesOptions={{
            borderRadius: 12,
            color: '#F5BF24',
          }}
          logo={{
            href: logoImg,
            padding: 4,
            // scale: 0.8,
            // hidePieces: false,
            // ... any other svg Image props (x, y, preserveAspectRatio, opacity, ...etc)
          }}
        />
      </View>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <Text style={styles.nameText}>Prvog goriva do limita: {user.firstFuelLeft}L</Text>
        <Text style={styles.nameText}>Drugog goriva do limita: {user.secondFuelLeft}L</Text>
      </View>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <Pressable style={styles.shareBtn} onPress={() => loadInBrowser()}>
          <Text style={styles.shareBtnText}>Podeli sa prijateljima</Text>
        </Pressable>
      </View>
      <View style={styles.promotionsView}>
        <Text style={styles.nameText}>Promocije</Text>
        <View style={styles.promotion}>
          <Image source={require('./../assets/kafa.png')} style={styles.kafaIcon}/>
          <Text style={styles.nameText}> 2 + 1 Kafa gratis</Text>
        </View>
        <View style={styles.whiteSpace}>
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
    paddingTop: 60,
    alignItems: 'center',
    justifyContent: 'center',
  },
  scrollView:{
    width: '100%',
  },
  root: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  svg: {
    marginTop: 20,
    backgroundColor: '#fff',
    borderRadius: 20,
    overflow: 'hidden',
  },
  logoContainer: {
    position: 'absolute',
    width: 88,
    height: 88,
    backgroundColor: '#fff',
    justifyContent: 'center',
    alignItems: 'center',
  },
  logo: {
    width: '90%',
    height: '90%',
    top: -2,
  },
  userIcon:{
    width: 50,
    height: 50,
  },
  nameText:{
    fontSize: 22,
    fontWeight: '700',
    marginTop: 5,
  },
  fuelText:{
    fontSize: 15,
    fontWeight: '400',
    color: '#8F8F8F',
  },
  shareBtn:{
    marginTop: 40,
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 15,
    paddingHorizontal: 32,
    width: '100%',
    borderRadius: 4,
    elevation: 4,
    backgroundColor: '#F5BF24',
  },
  shareBtnText:{
    fontSize: 22,
    fontWeight: '700',
  },
  promotionsView:{
    marginTop: 40,
  },
  promotion:{
    flexDirection: 'row', justifyContent: 'start', alignItems: 'center', marginTop: 10,
    marginTop: 20,
    width: '100%',
    height: 150,
    backgroundColor: '#F5BF24',
    borderRadius: 10,
  },
  receiptIcon:{
    width:40,
    height:40,
  },
  kafaIcon:{
    width:130,
    height:110,
    marginLeft: 20,
    marginTop: 20,
  },
  whiteSpace:{
    height:10,
  }
});
