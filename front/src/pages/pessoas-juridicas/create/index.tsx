import { useState } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { PessoaJuridicaContext } from '../../../contexts/PessoaJuridicaContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';
import { toast } from 'react-toastify';

const CreatePessoaJuridica = () => {
  const { addPessoaJuridica } = useContext(PessoaJuridicaContext)!;
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Inclui o código
  const [razaoSocial, setRazaoSocial] = useState('');
  const [inscricaoEstadual, setInscricaoEstadual] = useState('');
  const [cnpj, setCnpj] = useState('');
  const [ehRepresentante, setEhRepresentante] = useState(false);
  const [loading, setLoading] = useState(false);

  const handleCreatePessoaJuridica = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '') {
        throw new Error('O código é obrigatório.');
      }

      await addPessoaJuridica({
        codigo,
        razaoSocial,
        inscricaoEstadual,
        cnpj,
        ehRepresentante,
      });

      toast.success('Pessoa Jurídica criada com sucesso!');
      router.push('/pessoas-juridicas');
    } catch (error) {
      console.error('Erro ao criar pessoa jurídica:', error);
      toast.error('Erro ao criar pessoa jurídica.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.createPessoaJuridicaContainer}>
        <h1>Criar Nova Pessoa Jurídica</h1>
        <form onSubmit={handleCreatePessoaJuridica} className={styles.form}>
          <div className={styles.formGroup}>
            <label htmlFor="codigo">Código</label>
            <input
              id="codigo"
              type="number"
              value={codigo}
              onChange={(e) => setCodigo(Number(e.target.value))}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="razaoSocial">Razão Social</label>
            <input
              id="razaoSocial"
              type="text"
              value={razaoSocial}
              onChange={(e) => setRazaoSocial(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="inscricaoEstadual">Inscrição Estadual</label>
            <input
              id="inscricaoEstadual"
              type="text"
              value={inscricaoEstadual}
              onChange={(e) => setInscricaoEstadual(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="cnpj">CNPJ</label>
            <input
              id="cnpj"
              type="text"
              value={cnpj}
              onChange={(e) => setCnpj(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="ehRepresentante">
              <input
                id="ehRepresentante"
                type="checkbox"
                checked={ehRepresentante}
                onChange={(e) => setEhRepresentante(e.target.checked)}
              />
              É Representante
            </label>
          </div>

          <Button type="submit" loading={loading}>
            Criar Pessoa Jurídica
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default CreatePessoaJuridica;
